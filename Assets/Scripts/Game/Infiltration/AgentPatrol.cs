using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

namespace Infiltration
{
	/// <summary>
	/// Classe pour représenter un agent dans notre jeu d'infiltration
	/// </summary>
	public class AgentPatrol
	{
		private GameObject gameObject;
		private Vector3 src, dst;
		private float moveSpeed = 0.01f;

		private bool hasSeenPlayer;
		private Vector3 targetDetected;

		private AudioClip tokenGrabClip;

		private AudioSource tokenGrab;

		public AgentPatrol(GameObject go, Vector3 src, Vector3 dst)
		{
			// On assigne le gameObject de l'agent correspondant
			this.gameObject = go;
			Transform transform = go.GetComponent<Transform>();
			// On lui assigne sa position de départ
			transform.position = src;

			this.src = src;
			this.dst = dst;
			SetRotation(dst);

			this.hasSeenPlayer = false;

			FieldOfView fov = gameObject.GetComponent<FieldOfView>();
			this.tokenGrab = AddAudio(fov.tokenGrabClip, false, false, 0.5f);
		}

		/// <summary>
		/// Helper pour tourner l'agent dans le sens de sa marche
		/// </summary>
		/// <params name="target">
		/// La cible vers laquelle l'agent marche
		/// </params>
		private void SetRotation(Vector3 target)
		{
			Transform transform = gameObject.GetComponent<Transform>();
			Vector3 targetDir = (target - transform.position);

			float targetAngle = Vector3.SignedAngle(targetDir, Vector3.forward, -Vector3.up);
			transform.rotation = Quaternion.Euler(0, targetAngle, 0);
		}

		/// <summary>
		/// Helper créer une AudioSource
		/// </summary>
		private AudioSource AddAudio(AudioClip clip, bool isLoop, bool isPlayAwake, float vol)
		{
			AudioSource newAudio = gameObject.AddComponent<AudioSource>() as AudioSource;
			newAudio.clip = clip;
			newAudio.loop = isLoop;
			newAudio.playOnAwake = isPlayAwake;
			newAudio.volume = vol;
			return newAudio;
		}


		/// <summary>
		/// Action d'aller vers la cible qui a été précédement détecté
		/// </summary>
		public State MoveToTarget()
		{
			Transform transform = gameObject.GetComponent<Transform>();

			Vector3 playerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			playerPos = new Vector3(playerPos.x, 0, playerPos.z);

			transform.position = Vector3.Lerp(transform.position, targetDetected, moveSpeed);
			SetRotation(playerPos);

			return State.SUCCESS;
		}

		/// <summary>
		/// Action de détection du joueur
		/// </summary>
		public State Detection()
		{
			Transform transform = gameObject.GetComponent<Transform>();
			FieldOfView fov = gameObject.GetComponent<FieldOfView>();

			// On calcule la position du joueur
			Vector3 playerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			playerPos = new Vector3(playerPos.x, 0, playerPos.z);


			// On récupére la cible courante
			Vector3 target = dst;
			if (hasSeenPlayer)
			{
				target = targetDetected;
			}
			// On calcule la direction de la marche de notre agent
			Vector3 lookDir = Vector3.Normalize(target - transform.position);
			// On calcule la direction que devrait prendre l'agent pour rejoindre le joueur
			Vector3 playerDir = (playerPos - transform.position);

			// On trouve l'angle entre l'agent et le joueur
			float playerAngle = Vector3.Angle(playerDir, lookDir);

			// On trouve la distance entre l'agent et le joueur
			float playerDist = Vector3.Distance(playerPos, transform.position);

			// Si l'angle et la distance sont trop grand, pas de détection
			if (playerAngle <= fov.angle_fov * 1.25f && playerDist <= fov.dist_max * 1.25f)
			{
				// On fait un raycast pour s'assurer qu'il n'y a pas d'autre objet qui cache le joueur
				if (!Physics.Raycast(transform.position, playerDir, playerDist))
				{
					hasSeenPlayer = true;
					targetDetected = playerPos - Vector3.Normalize(playerDir);
					fov.newMaterial.SetColor("_Color", Color.red);
					return State.SUCCESS;
				}
			}

			hasSeenPlayer = false;
			fov.newMaterial.SetColor("_Color", Color.white);
			return State.FAILURE;
		}

		/// <summary>
		/// Action de tire
		/// </summary>
		public State Fire()
		{
			// On joue un son de coup de feu
			FieldOfView fov = gameObject.GetComponent<FieldOfView>();
			tokenGrab.PlayOneShot(fov.tokenGrabClip);

			return State.SUCCESS;
		}

		/// <summary>
		/// Action de patrouille
		/// </summary>
		public State Patrol()
		{
			Transform transform = gameObject.GetComponent<Transform>();

			// Si le joueur a atteint le point B, on fait demi tour
			var margin = 0.1f;
			if (dst.x - margin <= transform.position.x && transform.position.x <= dst.x + margin &&
				dst.z - margin <= transform.position.z && transform.position.z <= dst.z + margin)
			{
				Vector3 tmp = dst;
				dst = src;
				src = tmp;
			}

			// L'agent se déplace tranquillement d'un point A à B
			transform.position = Vector3.Lerp(transform.position, dst, moveSpeed);
			SetRotation(dst);

			return State.SUCCESS;
		}
	}
}
