using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
    public void Init()
	{
		GameObject root = GameObject.Find("@Sound");
		if (root == null)
		{
			root = new GameObject { name = "@Sound" };
			Object.DontDestroyOnLoad(root);

			string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));
			for (int i = 0; i < soundNames.Length - 1; i++)
			{ 
				GameObject go = new GameObject { name = soundNames[i] };
				_audioSources[i] = go.AddComponent<AudioSource>();
				go.transform.parent=root.transform;
			}

			_audioSources[(int)Define.Sound.Bgm].loop = true;
		}
	}

	//float pitch = 1.0f �̷��� �ϸ� �ɼ�
	public void Play(Define.Sound type, string path, float pitch = 1.0f)
	{
		if (path.Contains("Sounds/") == false)
			path = $"Sounds/{path}";

		if (type == Define.Sound.Bgm)
		{
			AudioClip audioClip = Resources.Load<AudioClip>("Sounds/retro");//= Managers.Resource.Load<AudioClip>(path);
			if (audioClip == null)
			{
				Debug.Log($"AudioClip Missing ! {path}");
				return;
			}
			// TODO
		}
		else
		{
			AudioClip audioClip = Resources.Load<AudioClip>("Sounds/zoom");//= Managers.Resource.Load<AudioClip>(path);//Managers.Resource.Load<AudioClip>(path);
            if (audioClip == null)
			{
				Debug.Log($"AudioClip Missing ! {path}");
				return;
			}
			//�̰� �� �� ���� �Ǵµ� �׳� �ڵ� �������� ���ؼ��� �� ����.
			AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
			audioSource.pitch = pitch;
			audioSource.PlayOneShot(audioClip);
		}

	}
}