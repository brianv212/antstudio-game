using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;

    public Text gameOverText;
    public Text scoreText;
    public Text livesText;
    public Text testText;
    public Text winText;

    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        this.gameOverText.enabled = false;

        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState() // TODO: convert to SetState(bool). ResetState() => SetState(true). GameOver() => SetState(false).
    {
        ResetGhostMultiplier();
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            // this.ghosts[i].gameObject.SetActive(true);
            this.ghosts[i].ResetState();
        }

        //this.pacman.gameObject.SetActive(true);
        this.pacman.ResetState();
    }

    private void GameOver()
    {
        this.gameOverText.enabled = true;

        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        this.score = score;
        this.scoreText.text = score.ToString().PadLeft(2, '0');
        // this.scoreText.text = "Dogs!".PadLeft(2, '0');
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        this.livesText.text = "x" + lives.ToString();
    }

    public void GhostEaten(Ghost ghost)
    {
        int points = ghost.points * this.ghostMultiplier;
        SetScore(this.score + points);
        this.ghostMultiplier++;
    }

    public void PacmanEaten()
    {
        // TO-DO: Set a death animation/sequence
        //this.pacman.DeathSequence();
        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);

        if (this.lives > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
            //ResetState();
        }
        else
        {
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);
        SetScore(this.score + pellet.points);

        if (!HasRemainingPellets())
        {
            this.pacman.gameObject.SetActive(false); // avoids a ghost eating you while you're waiting for transition

            // MAYBE do this if we just want to optionally add an infinite Pacman for fun.
            //Invoke(nameof(NewRound), 3.0f);
            this.winText.enabled = true;
        }
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].frightened.Enable(pellet.duration);
        }

        PelletEaten(pellet);

        if (score < 300 && SceneManager.GetActiveScene().name == "Pacman")
        {
            // To-do: Early end. When the player rushes for a power pellet, we end Pacman early. Otherwise the player can play the whole game if they'd like.
            // Up next: Peter walks out of a door and has text-dialogue with himself.
            this.pacman.gameObject.SetActive(false);
            this.testText.enabled = true;
            Invoke(nameof(LoadScene), pellet.duration);
        }
        else
        {
            CancelInvoke(nameof(ResetGhostMultiplier));
            Invoke(nameof(ResetGhostMultiplier), 3.0f);
        }
        
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Cutscene");
    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf) 
            {
                return true; // check every pellet in our array of pellets to see if they're all active or inactive
            }
        }

        return false;
    }

    private void ResetGhostMultiplier()
    {
        this.ghostMultiplier = 1;
    }
}
