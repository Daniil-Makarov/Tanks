using UnityEngine;

namespace progdamn.Core.Services {
	public class TimeManager {
		public void StopTime() => Time.timeScale = 0;
	}
}