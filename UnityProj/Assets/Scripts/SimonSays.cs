using UnityEngine;
using System.Collections;

public class SimonSays : MonoBehaviour
{
    // Public global variables
    public int difficulty;
    public GameObject[] cubeArr;

    void Start()
    {
        counter = 0;
        simonState = SimonSaysState.e_PATTERN_CREATE;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(simonState);
        switch(simonState)
        {
            case SimonSaysState.e_PATTERN_CREATE:
                CreatePattern(cubeArr.Length, difficulty);
                Debug.Log(pattern.Length + " digit pattern is " + pattern[0] + ", " + pattern[1] + ", " + pattern[2] + ", " + pattern[3]);
                break;

            case SimonSaysState.e_PATTERN_PLAYBACK:
                PatternPlayback(difficulty);
                break;

            case SimonSaysState.e_USER_TURN:
                UserTurn();
                break;
        }
    }

    /// <summary>
    /// Create a pattern using the number of gameObjects in the game
    /// where the pattern is "length" long.
    /// </summary>
    /// <param name="reps">Reps.</param>
    void CreatePattern(int buttonRange, int patternLength)
    {
        // create a vector of random ints, within a range
        pattern = new int[patternLength *= 4];

        // create a pattern as long as "patternLength",
        // put a number within chosen range into the array
        for (int i = 0; i < patternLength; i++)
            pattern[i] = Random.Range(0, buttonRange);

        simonState = SimonSaysState.e_PATTERN_PLAYBACK;
    }

    /// <summary>
    /// Highlight the cubes in the order set by "PatternCreate"
    /// at desired speed
    /// </summary>
    void PatternPlayback(float difficultyBasedSpeed)
    {
        //for (int i = 0; i < pattern.Length; i++) 
        if (counter > pattern.Length) counter = 0;
        timer += Time.deltaTime;
        Debug.Log(counter);

        if (timer > difficultyBasedSpeed)
        {
            timer = 0;
            switch (counter)
            {
                case 0:
                    // pulse the    cube of  pattern spot "_"
                    pulseInstance = cubeArr[pattern[0]].GetComponent<Pulse>();
                    pulseInstance.pulseActive = true;
                    counter++;
                    break;
                case 1:
                    pulseInstance = cubeArr[pattern[1]].GetComponent<Pulse>();
                    pulseInstance.pulseActive = true;
                    counter++;
                    break;
                case 2:
                    pulseInstance = cubeArr[pattern[2]].GetComponent<Pulse>();
                    pulseInstance.pulseActive = true;
                    counter++;
                    break;
                case 3:
                    pulseInstance = cubeArr[pattern[3]].GetComponent<Pulse>();
                    pulseInstance.pulseActive = true;
                    counter++;
                    break;
            }
        }
        simonState = SimonSaysState.e_USER_TURN;
    }

    void UserTurn()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(Input.mousePosition, fwd, 10))
        {
            Debug.DrawRay(Input.mousePosition, fwd);
        }
    }

    // Private global vars
    int[] pattern;

    // Other scripts communicated with
    Pulse pulseInstance;

    // Private global vars for pattern playback
    int counter;
    float timer;

    enum SimonSaysState
    {
        e_PATTERN_CREATE,
        e_PATTERN_PLAYBACK,
        e_USER_TURN
    }

    SimonSaysState simonState;
}
