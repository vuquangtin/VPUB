package com.swt.utilities;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Timer;
import java.util.TimerTask;
import java.util.logging.FileHandler;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;

public class Logging {

	private static Logging Instance = new Logging();

	public static Logging getInstance() {
		return Instance;
	}

	private final Logger logger = Logger.getLogger(Logging.class.getName());
	private FileHandler fh = null;

	public void stop() {
		fh.close();
	}

	public Logging() {
		try {
			// kiểm tra folder log
			File file = new File("logs");
			if (!file.exists()) {
				file.mkdir();
			}
			
			fh = new FileHandler("logs/"
					+ new SimpleDateFormat("yyyy-MM-dd").format(Calendar
							.getInstance().getTime()) + ".log", true  /*append to file*/);
			 
			fh.setFormatter(new SimpleFormatter());
			logger.addHandler(fh);
			startLogs();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public void startLogs() {
		Timer timer = new Timer();
		timer.schedule(new TimerTask() {
			@Override
			public void run() {
				try {
					File file = new File("logs/"
							+ new SimpleDateFormat("yyyy-MM-dd")
									.format(Calendar.getInstance().getTime())
							+ ".log");
					if (!file.exists()) {
						fh.close();
						fh = new FileHandler(file.getAbsolutePath(), true /*append to file*/);
						fh.setFormatter(new SimpleFormatter());
						logger.addHandler(fh);
					}
				} catch (Exception e) {
				}
			}
		}, 0, 300000);
	}

	public void writeError(String msg) {
		logger.severe(msg);
	}

	public void writeInfo(String msg) {
		logger.info(msg);
	}
	
	public void writeWarning(String msg){
		logger.warning(msg);
	}

	public void writeFine(String msg) {
		logger.fine(msg);
	}
}
