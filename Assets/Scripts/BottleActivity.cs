using UnityEngine;

using TMPro; 

public class BottleSocket : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor[] sockets; // four sockets to check
    public TextMeshProUGUI completionText; // text screen
    public AudioSource completionSound; // audio

    private int occupiedSocketCount = 0; // track # of sockets filled

    void Update()
    {
        int currentOccupiedCount = CountOccupiedSockets();

        // if count changes update text
        if (currentOccupiedCount != occupiedSocketCount)
        {
            occupiedSocketCount = currentOccupiedCount;
            UpdateCompletionText();
        }

        // If all sockets filled, call func
        if (AreAllSocketsOccupied())
        {
            DisplayCompletion();
        }
    }

    private int CountOccupiedSockets()
    {
        int count = 0;

        foreach (var socket in sockets)
        {
            if (socket.hasSelection) // if socket is occupied
            {
                count++;
            }
        }

        return count;
    }

    private bool AreAllSocketsOccupied()
    {
        return occupiedSocketCount == sockets.Length; // check if all sockets are filled
    }

    private void UpdateCompletionText()
    {
        if (completionText != null)
        {
            completionText.text = $"Bottles Collected: {occupiedSocketCount}/{sockets.Length}";
        }
    }

    private void DisplayCompletion()
    {
        if (completionText != null)
        {
            completionText.text = "Thanks for helping clean up!"; 
        }

        if (completionSound != null && !completionSound.isPlaying)
        {
            completionSound.Play(); 
        }

        this.enabled = false;
    }
}
