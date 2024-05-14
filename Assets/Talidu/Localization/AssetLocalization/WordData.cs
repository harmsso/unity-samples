#region

using System;
using UnityEngine;

#endregion

namespace Localization.AssetLocalization
{
    /// <summary>
    /// Base data container for word specific data and resources.
    /// </summary>
    [Serializable]
    public class WordData
    {
        public string Word;
        public string Levels;
        public AudioClip WordAudio;
        public AudioClip SentenceAudio;
        public Texture Texture;
        public string[] Grapheme;
        public string Sentence;
        public string Errors;
    }

    /// <summary>
    /// Data container for german words.
    /// </summary>
    [Serializable]
    public class GermanWordData : WordData
    {
        public string Artikel;
    }
}