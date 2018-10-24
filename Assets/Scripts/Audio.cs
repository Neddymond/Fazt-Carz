using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Audio : MonoBehaviour
    {
        public AudioSource audiosource;
        public AudioClip SoundClip;

        private void OnCollisionEnter(Collision collision)
        {
            audiosource.PlayOneShot(SoundClip);
        }
    }

   
}
