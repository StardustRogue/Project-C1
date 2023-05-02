using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("General Attributes")]
    public TextMeshProUGUI _nameText;
    public TextMeshProUGUI _dialogueText;

    [SerializeField]
    [Range(0f, 0.1f)]
    public float _textSpeed;

    public Animator _animator;

    private Queue<string> _sentences;
    // Start is called before the first frame update
    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        _animator.SetBool("IsOpen", true);

        _nameText.text = dialogue._name;

        _sentences.Clear();

        foreach (string sentence in dialogue._sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        _dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            _dialogueText.text += letter;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    void EndDialogue()
    {
        _animator.SetBool("IsOpen", false);
    }
}
