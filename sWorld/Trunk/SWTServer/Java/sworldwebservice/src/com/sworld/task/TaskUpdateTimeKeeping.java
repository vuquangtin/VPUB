package com.sworld.task;

import java.util.Calendar;

import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;
import com.swt.timekeeping.impls.*;

public class TaskUpdateTimeKeeping implements ServletContextListener {
	private Thread t = null;

	public void contextInitialized(ServletContextEvent contextEvent) {
		t = new Thread() {
			// task
			public void run() {
				try {
					System.out.println("Task update timekeeping start!!!");
					while (true) {
						Thread.sleep(3600000);
						Calendar rightNow = Calendar.getInstance();
						System.out.println("Time: "
								+ rightNow.get(Calendar.HOUR_OF_DAY));
						if (rightNow.get(Calendar.HOUR_OF_DAY) == 1) {
							TimeKeepingMonthlyReportController.Instance.updateRepport();
							System.out.println("Updated Monthly Report");
						}
					}
				} catch (InterruptedException e) {
				}
			}
		};
		t.start();
	}

	public void contextDestroyed(ServletContextEvent contextEvent) {
		// context is destroyed interrupts the thread
		t.interrupt();
	}
}
