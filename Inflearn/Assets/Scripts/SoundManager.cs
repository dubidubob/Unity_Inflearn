using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager
{
	AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
	//float pitch = 1.0f 이렇게 하면 옵션
	public void Play(Define.Sound.type, string path, float pitch = 1.0f)
	{
		if (path.Contains("Sounds/") == false)
			path = $"Sounds/{path}";

		if (type = Define.Sound.Bgm)
		{
			AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);
			if (audioClip == null)
			{
				//Debug.Log($"AudioClip Missing ! {path}");
				return;
			}
			// TODO
		}
		else
		{
			AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);
			if (audioClip == null)
			{
				//Debug.Log($"AudioClip Missing ! {path}");
				return;
			}
			//이거 또 안 만들어도 되는데 그냥 코드 가독성을 위해서인 것 같다.
			AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
			audioSource.pitch = pitch;
			audioSource.PlayOneShot(audioClip);
		}

	}
}


}