import java.io.IOException;
import java.util.Timer;
import java.util.TimerTask;
import com.swt.devices.MCR02;
import com.swt.object.Session;
import com.swt.service.SystemService;
import com.swt.utilities.AppConfig;
import com.swt.utilities.Logging;
import com.swt.utilities.Utilities;

public class Main {

	/**
	 * @param args
	 * @throws IOException
	 */

	private static Session session = null;

	public static void main(String[] args) throws IOException {

		try {
			checkServer();
			start();
		} catch (Exception e) {
			e.printStackTrace();
		}

	}

	public static void start() {
		try {
			MCR02.getInstance().accessStart();
			MCR02.getInstance().startAccessProcessor();

			MCR02.getInstance().cameraStart();
			MCR02.getInstance().startCameraTimeKeeping(1);
			Thread.sleep(AppConfig.getInstance().getTimeInspectionCamera());
			MCR02.getInstance().checkCamera();
		} catch (Exception e) {
		}
	}

	public static void checkServer() {
		try {
			Timer timer = new Timer();
			timer.schedule(new TimerTask() {
				@Override
				public void run() {
					try {
						try {
							session = SystemService.getInstance().login();
						} catch (Exception e) {
							e.printStackTrace();
						}
						if (session == null) {
							try{
							Logging.getInstance()
									.writeError(
											"Cannot login to server at "
													+ Utilities
															.getInstance()
															.getCurrentDateStrDDMMYYYY());
							}catch (Exception e) {
								e.printStackTrace();
							}
						} else {
							try{
							Logging.getInstance()
									.writeInfo(
											"Login sucessful to server at "
													+ Utilities
															.getInstance()
															.getCurrentDateStrDDMMYYYY());
							}catch (Exception e) {
								e.printStackTrace();
							}
						}
						AppConfig.getInstance().LoadConfig();
					} catch (Exception e) {
						e.printStackTrace();
					}
				}
			}, 0, AppConfig.getInstance().getTimeInspectionServer());
		} catch (Exception e) {
			e.printStackTrace();
			Logging.getInstance().writeError(e.getMessage());
		}
	}
}
