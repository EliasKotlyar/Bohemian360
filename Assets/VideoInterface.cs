using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MMT;

public class VideoInterface : MonoBehaviour
{
	public List<MobileMovieTexture> movieTextures;
	public List<AudioSource> audioSources;

    public int numberElements;
    public int radius;
    protected int degrees;

	private double startTime;

    void Start()
    {
		this.degrees = 360 / numberElements;
		movieTextures = new List<MobileMovieTexture>();
		audioSources = new List<AudioSource>();

		startTime = AudioSettings.dspTime + 5.0f;

        putCubetoScene(numberElements);

		StartCoroutine (startVideos ());
    }

	private IEnumerator startVideos() {
		while (AudioSettings.dspTime < startTime) {
			yield return null;
		}
		foreach (MobileMovieTexture tex in movieTextures) {
			//tex.Play ();
		}
	}

    private void putCubetoScene(int num_el )
    {
        float deg = this.degrees;
        float radius = this.radius;

        for (int i = 0; i < num_el; i++)
        {
            //GameObject plane = GameObject.CreatePrimitive (PrimitiveType.Plane);
            GameObject plane = this.createVideoObject(i);
            const float PI = 3.1415926f;
            float alpha = i * deg;
            plane.transform.position = new Vector3(-radius * Mathf.Sin(PI * alpha / 180), 0, radius * Mathf.Cos(PI * alpha / 180));
            Quaternion vec1 = Quaternion.Euler(new Vector3(-90, -alpha, 0));
            Quaternion vec2 = Quaternion.Euler(new Vector3(0, 180, 0));

            plane.transform.rotation = vec1 * vec2;//-90, -alpha, 0);

			this.createAudioObject(i);
        }
    }
    private GameObject createVideoObject(int id)
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.name = "Plane #" + id.ToString();

        MeshRenderer meshRenderer = plane.GetComponent<MeshRenderer>();
        Shader videoShader = Shader.Find("Color Space/YCbCrtoRGB");
        Material videoMaterial = new Material(videoShader);
        videoMaterial.name = "Material #" + id.ToString();
        meshRenderer.material = videoMaterial;

		GameObject videoObject = new GameObject();
        MobileMovieTexture tex = videoObject.AddComponent<MobileMovieTexture>();
		//tex.PlayAutomatically = false;
        tex.name = "MovieTexture #" + id.ToString();
		movieTextures.Add (tex);

        Material[] matArray = new Material[1];
        matArray[0] = videoMaterial;
        tex.MovieMaterial = matArray;

        tex.Path = "video" + id.ToString() + ".ogv";

        return plane;
    }



	private void createAudioObject(int id)
	{
		GameObject musicObject = new GameObject();
		AudioSource audioSource = musicObject.AddComponent<AudioSource>();
		audioSource.name = "AudioObject_1 " + id.ToString();
		audioSource.clip = Resources.Load ("audio"+id.ToString()) as AudioClip;
		audioSource.loop = true;
		audioSource.PlayScheduled (startTime);

		audioSources.Add (audioSource);
	}


    // Update is called once per frame
    void Update ()
	{
		float fYRot = Camera.main.transform.eulerAngles.y;
		int j = 0;
		foreach (AudioSource src in audioSources) {
			src.volume = soundFunction(fYRot,j*51.0F);
			j++;
		}
	}


	float soundFunction(float rotAngle,float screenPos)
	{
		float phi = Mathf.Abs(rotAngle - screenPos) % 360;
		float diff = phi > 180 ? 360 - phi : phi;

		if (diff > this.degrees * 1.5f) {
			return 0.0f;
		}
		return Mathf.Exp(-Mathf.Pow(diff, 2)/(200*Mathf.PI));
	}
}
