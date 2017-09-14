package com.swt.nonresident.impls;

import java.awt.image.BufferedImage;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.imageio.ImageIO;

import org.apache.tomcat.util.codec.binary.Base64;
import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.domain.NonResident;
import com.swt.meeting.impls.MeetingController;
import com.swt.meeting.lib.tm.Constant;
import com.swt.nonresident.INonResident;
import com.swt.nonresident.customObject.NonResidentObj;
import com.swt.nonresident.customObject.NonResidentStatistic;
import com.swt.nonresident.customObject.NonResidentStatisticDetailObj;
import com.swt.nonresident.customObject.NonResidentStatisticObj;

public class NonResidentDAO implements INonResident {
	private static final String SERIALNUMBER_CANCELED = "00000000";

	// Noi luu hinh anh
	public static final String NON_RESIDENT_IMAGE_DIR_FACE = "/ImageNonResidentFace";
	public static final String NON_RESIDENT_IMAGE_DIR_IDENTITY_CARD = "/ImageNonResidentIdentityCard";
	public static final String NON_RESIDENT_IMAGE_DIR_FACE_CHILD = (new SimpleDateFormat("yyyy-MM")).format(new Date());
	public static final String NON_RESIDENT_IMAGE_DIR_IDENTITY_CARD_CHILD = (new SimpleDateFormat("yyyy-MM"))
			.format(new Date());

	/**
	 * insert nonresident
	 * 
	 * @param nonResident
	 * @return NonResident
	 */
	@Override
	public NonResident insert(NonResident nonResident) {
		// tang so luong khach vang lai vao mot cuoc hop
		MeetingController.Instance.increasePersonAttend(nonResident.getMeetingId(), Constant.NONRESIDON);
		return HibernateUtil.insertObject(nonResident);
	}

	/**
	 * update nonresident
	 * 
	 * @param nonResident
	 * @return NonResident
	 */
	public NonResident update(NonResident nonResident) {
		return HibernateUtil.updateObject(nonResident);
	}

	/**
	 * kiem tra the co ton tai khong
	 * 
	 * @param serialnumber
	 * @return NonResident
	 */
	@Override
	public NonResidentObj checkInOutNonResidentBySerialNumberAndDateime(String serialnumber) {
		Session session = HibernateUtil.getSession();

		NonResidentObj result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM NonResident WHERE isOrgOther = FALSE AND serialnumber = :serialnumber ";
			Query query = session.createQuery(strQuery);
			query.setParameter("serialnumber", serialnumber);

			NonResident resultSQL = (NonResident) query.uniqueResult();
			session.getTransaction().commit();
			if (resultSQL != null) {
				result = new NonResidentObj();
				result.setNonResident(resultSQL);
			}
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	/**
	 * update outputTime va huy the
	 * 
	 * @param serialnumber
	 * @param date
	 * @return boolean
	 */
	@Override
	public boolean updateOutputTimeNonResident(String serialNumber, Date date) {
		if (checkInOutNonResidentBySerialNumberAndDateime(serialNumber) != null) {
			Session session = HibernateUtil.getSession();
			try {
				session.getTransaction().begin();

				String strQuery = "UPDATE NonResident SET outputTime = :outtime, serialnumber = :cancel  WHERE serialnumber = :serialnumber ";
				Query query = session.createQuery(strQuery);
				query.setParameter("serialnumber", serialNumber);
				query.setParameter("cancel", SERIALNUMBER_CANCELED);
				query.setParameter("outtime", date);
				query.executeUpdate();
				session.getTransaction().commit();
			} catch (HibernateException e) {
				session.getTransaction().rollback();
				e.printStackTrace();
			} finally {
				session.flush();
				session.clear();
				session.close();
			}

			return true;
		} else
			return false;
	}

	/**
	 * get nonresident by serial number
	 * 
	 * @param serialnumber
	 * @return NonResident
	 */
	@Override
	public NonResident getNonResidentBySerialNumber(String serialnumber) {
		Session session = HibernateUtil.getSession();

		NonResident result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM NonResident WHERE isOrgOther = FALSE AND serialnumber = :serialnumber";
			Query query = session.createQuery(strQuery);
			query.setParameter("serialnumber", serialnumber);

			result = (NonResident) query.uniqueResult();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	/**
	 * tong so luong nonresidentstatistic
	 * 
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	@Override
	public long sumNonResidentStatisticByDate(Date fromDate, Date toDate) {
		Session session = HibernateUtil.getSession();

		long result = 0;
		try {
			session.getTransaction().begin();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");
			String strQuery = "SELECT count(*) " + "FROM NonResident "
					+ "WHERE isOrgOther = FALSE AND inputTime BETWEEN :fromDate AND :toDate " + "GROUP BY orgId ";
			Query query = session.createQuery(strQuery);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));

			result = query.list().size();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	/**
	 * thong ke so luong khach vang lai tu ngay den ngay theo co quan nguoi do
	 * den
	 * 
	 * 
	 * @param start
	 * @param end
	 * @param fromDate
	 * @param toDate
	 * @return long
	 */
	@SuppressWarnings("unchecked")
	@Override
	public NonResidentStatisticObj getListNonResidentStatisticByDate(int start, int end, Date fromDate, Date toDate) {
		Session session = HibernateUtil.getSession();

		NonResidentStatisticObj result = null;
		try {
			session.getTransaction().begin();

			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");
			String strQuery = "SELECT orgId, orgName, count(*) " + " FROM NonResident "
					+ " WHERE isOrgOther = FALSE AND inputTime BETWEEN :fromDate AND :toDate " + "GROUP BY orgId ";
			Query query = session.createQuery(strQuery);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setFirstResult(start);
			query.setMaxResults(end);

			List<Object[]> nonResidentStatistics = (List<Object[]>) query.list();
			if (nonResidentStatistics.size() > 0) {
				result = new NonResidentStatisticObj();
				session.getTransaction().commit();

				List<NonResidentStatistic> list = new ArrayList<NonResidentStatistic>();

				for (Object[] objectTmp : nonResidentStatistics) {
					NonResidentStatistic nonResidentStatistic = new NonResidentStatistic();
					nonResidentStatistic.setOrgId((Long) objectTmp[0]);
					nonResidentStatistic.setOrgName((String) objectTmp[1]);
					nonResidentStatistic.setNumber((long) objectTmp[2]);
					list.add(nonResidentStatistic);
				}
				result.setNonResidentStatistics(list);
				// set tong so luong de client phan trang
				result.setSum(sumNonResidentStatisticByDate(fromDate, toDate));
			}

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	/**
	 * thong ke chi tiet tat ca co quan co nhung nguoi nao da vao tu ngay den
	 * ngay
	 * 
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	@SuppressWarnings("unchecked")
	@Override
	public NonResidentStatisticDetailObj getListNonResidentByDate(int start, int end, Date fromDate, Date toDate,
			long orgId) {
		Session session = HibernateUtil.getSession();

		NonResidentStatisticDetailObj result = null;
		List<NonResidentObj> nonResidentObjs = null;
		List<NonResident> nonResidents = null;
		try {
			session.getTransaction().begin();

			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");
			String strQuery = "FROM NonResident "
					+ "WHERE isOrgOther = FALSE AND orgId = :orgId AND inputTime BETWEEN :fromDate AND :toDate ";
			Query query = session.createQuery(strQuery);
			query.setLong("orgId", orgId);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setFirstResult(start);
			query.setMaxResults(end);
			nonResidents = query.list();
			session.getTransaction().commit();

			if (nonResidents.size() > 0) {
				result = new NonResidentStatisticDetailObj();
				nonResidentObjs = new ArrayList<NonResidentObj>();
				// them 2 buc hinh da chup vao doi tuong
				for (NonResident nonResident : nonResidents) {
					NonResidentObj nonResidentObj = new NonResidentObj();
					nonResidentObj.setNonResident(nonResident);
					nonResidentObj.setDataImageFace(getImageFace(nonResident.getId()));
					nonResidentObj.setDataImageIdentityCard(getImageIdentityCard(nonResident.getId()));
					nonResidentObjs.add(nonResidentObj);
				}
				result.setNonResidentObjs(nonResidentObjs);
				// set tong so luong de client phan trang
				result.setSum(sumListNonResidentByDate(fromDate, toDate, orgId));
			}
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}
	
	/**
	 * thong ke chi tiet theo co quan va theo nguoi hoac suborg trong co quan do
	 * 
	 * @param start
	 * @param end
	 * @param fromDate
	 * @param toDate
	 * @param orgId
	 * @param memOrSubOrgId
	 * @param isPeople
	 * @return
	 */
	@SuppressWarnings("unchecked")
	@Override
	public NonResidentStatisticDetailObj getListNonResidentByDate(int start, int end, Date fromDate, Date toDate,
			long orgId, long memOrSubOrgId, int isPeople) {
		Session session = HibernateUtil.getSession();

		NonResidentStatisticDetailObj result = null;
		List<NonResidentObj> nonResidentObjs = null;
		List<NonResident> nonResidents = null;
		try {
			session.getTransaction().begin();

			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");
			String strQuery = "FROM NonResident "
					+ "WHERE isOrgOther = FALSE AND orgId = :orgId AND nonMemOrSubOrgId = :memOrSubOrgId AND isPeople = :isPeople"
					+ " AND inputTime BETWEEN :fromDate AND :toDate ";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgId", orgId);
			query.setParameter("memOrSubOrgId", memOrSubOrgId);
			query.setParameter("isPeople", isPeople);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setFirstResult(start);
			query.setMaxResults(end);
			nonResidents = query.list();
			session.getTransaction().commit();

			if (nonResidents.size() > 0) {
				result = new NonResidentStatisticDetailObj();
				nonResidentObjs = new ArrayList<NonResidentObj>();
				// them 2 buc hinh da chup vao doi tuong
				for (NonResident nonResident : nonResidents) {
					NonResidentObj nonResidentObj = new NonResidentObj();
					nonResidentObj.setNonResident(nonResident);
					nonResidentObj.setDataImageFace(getImageFace(nonResident.getId()));
					nonResidentObj.setDataImageIdentityCard(getImageIdentityCard(nonResident.getId()));
					nonResidentObjs.add(nonResidentObj);
				}
				result.setNonResidentObjs(nonResidentObjs);
				// set tong so luong de client phan trang
				result.setSum(sumListNonResidentByDate(fromDate, toDate, orgId));
			}
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	/**
	 * thong ke chi tiet mot co quan co bao nhieu nguoi da vao tu ngay den ngay
	 * 
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<NonResidentObj> getListNonResidentByOrgIdAndDate(int start, int end, Date fromDate, Date toDate,
			long orgId) {
		Session session = HibernateUtil.getSession();

		List<NonResidentObj> result = null;
		try {
			session.getTransaction().begin();

			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");
			String strQuery = "FROM NonResident "
					+ "	WHERE isOrgOther = FALSE AND orgId = :orgId AND inputTime BETWEEN :fromDate AND :toDate ";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgId", orgId);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setFirstResult(start);
			query.setMaxResults(end);
			List<NonResident> nonResidents = query.list();

			session.getTransaction().commit();

			// them 2 buc hinh da chup vao doi tuong
			if (nonResidents.size() > 0) {
				result = new ArrayList<NonResidentObj>();
				for (NonResident nonResident : nonResidents) {
					NonResidentObj nonResidentObj = new NonResidentObj();
					nonResidentObj.setNonResident(nonResident);
					nonResidentObj.setDataImageFace(getImageFace(nonResident.getId()));
					nonResidentObj.setDataImageIdentityCard(getImageIdentityCard(nonResident.getId()));
					result.add(nonResidentObj);
				}
			}

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	/**
	 * thong ke chi tiet tat ca co quan co nhung nguoi nao da vao tu ngay den
	 * ngay
	 * 
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	@SuppressWarnings("unchecked")
	@Override
	public NonResidentStatisticDetailObj getListNonResidentByDate(int start, int end, Date fromDate, Date toDate) {
		Session session = HibernateUtil.getSession();

		NonResidentStatisticDetailObj result = null;
		List<NonResidentObj> nonResidentObjs = null;
		List<NonResident> nonResidents = null;
		try {
			session.getTransaction().begin();

			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");
			String strQuery = "FROM NonResident "
					+ "WHERE  isOrgOther = FALSE AND inputTime BETWEEN :fromDate AND :toDate ";
			Query query = session.createQuery(strQuery);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setFirstResult(start);
			query.setMaxResults(end);
			nonResidents = query.list();
			session.getTransaction().commit();

			if (nonResidents.size() > 0) {
				result = new NonResidentStatisticDetailObj();
				nonResidentObjs = new ArrayList<NonResidentObj>();
				// them 2 buc hinh da chup vao doi tuong
				for (NonResident nonResident : nonResidents) {
					NonResidentObj nonResidentObj = new NonResidentObj();
					nonResidentObj.setNonResident(nonResident);
					nonResidentObj.setDataImageFace(getImageFace(nonResident.getId()));
					nonResidentObj.setDataImageIdentityCard(getImageIdentityCard(nonResident.getId()));
					nonResidentObjs.add(nonResidentObj);
				}
				result.setNonResidentObjs(nonResidentObjs);
				// set tong so luong de client phan trang
				result.setSum(sumListNonResidentByDate(fromDate, toDate));
			}
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	// Duoc dung trong ham getListNonResidentByDate
	@Override
	public long sumListNonResidentByDate(Date fromDate, Date toDate) {
		Session session = HibernateUtil.getSession();

		long result = 0;
		try {
			session.getTransaction().begin();


			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");
			String strQuery = "SELECT count(*) " + "FROM NonResident "
					+ "WHERE isOrgOther = FALSE AND inputTime BETWEEN :fromDate AND :toDate ";
			Query query = session.createQuery(strQuery);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));

			result = (long) query.uniqueResult();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	@Override
	public long sumListNonResidentByDate(Date fromDate, Date toDate, long orgId) {
		Session session = HibernateUtil.getSession();

		long result = 0;
		try {
			session.getTransaction().begin();


			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");
			String strQuery = "SELECT count(*) " + "FROM NonResident "
					+ "WHERE isOrgOther = FALSE AND orgId = :orgId AND inputTime BETWEEN :fromDate AND :toDate ";
			Query query = session.createQuery(strQuery);
			query.setLong("orgId", orgId);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));

			result = (long) query.uniqueResult();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	// ---------------------------------------------//
	/**
	 * luu hinh chup mat khach vao
	 * 
	 * @param imageId
	 *            se tring voi NonResidentId
	 * @param _Image
	 *            parse thanh string
	 * @return imageId neu thanh cong, 0 la loi
	 */
	@Override
	public long insertImageFace(long imageId, String _Image) {
		if (_Image == null || _Image.equals("")) {
			return 0;
		}
		byte[] bitImage = Base64.decodeBase64(_Image);
		// ki?m tra xem c� thu m?c ch?a h�nh hay chua => t?o
		String tomcatDir = System.getProperty("catalina.home");
		File file = new File(tomcatDir + NON_RESIDENT_IMAGE_DIR_FACE);
		if (!file.exists()) {
			file.mkdir();
		}

		// Tach folder ra theo yyyy-mm de quan ly trong
		// NON_RESIDENT_IMAGE_DIR_FACE
		File fileChild = new File(tomcatDir + NON_RESIDENT_IMAGE_DIR_FACE + "//" + NON_RESIDENT_IMAGE_DIR_FACE_CHILD);
		if (!fileChild.exists()) {
			fileChild.mkdir();
		}

		BufferedImage bufferedImage = null;
		ByteArrayInputStream bais = new ByteArrayInputStream(bitImage);
		try {
			bufferedImage = ImageIO.read(bais);
		} catch (IOException e1) {
			e1.printStackTrace();
		}

		File fileImg = new File(tomcatDir + NON_RESIDENT_IMAGE_DIR_FACE + "//" + NON_RESIDENT_IMAGE_DIR_FACE_CHILD
				+ "//" + imageId + ".jpg");
		try {
			ImageIO.write(bufferedImage, "jpg", fileImg);
			return imageId;
		} catch (IOException e) {
			e.printStackTrace();
		}
		// l?i kh�ng th�m dc h�nh
		return 0;
	}

	/**
	 * lay hinh chup mat khach vao
	 * 
	 * @param imageId
	 *            se trung voi NonResidentId
	 * @return "" la loi
	 */
	@Override
	public String getImageFace(long imageId) {
		String tomcatDir = System.getProperty("catalina.home");
		File fi = new File(tomcatDir + NON_RESIDENT_IMAGE_DIR_FACE + "//" + NON_RESIDENT_IMAGE_DIR_FACE_CHILD + "//"
				+ imageId + ".jpg");
		if (fi.exists()) { // ki?m tra du?ng d?n
			byte[] bitImage = null;
			try {
				bitImage = Files.readAllBytes(fi.toPath());
			} catch (IOException e) {
				e.printStackTrace();
			}
			try {
				return Base64.encodeBase64String(bitImage);
			} catch (Exception ex) {
				// l?i kh�ng l?y du?c h�nh
			}
		}
		return "";
	}

	/**
	 * luu hinh chup cmnd khach vao
	 * 
	 * @param imageId
	 *            se tring voi NonResidentId
	 * @param _Image
	 *            parse thanh string
	 * @return imageId neu thanh cong, 0 la loi
	 */
	@Override
	public long insertImageIdentityCard(long imageId, String _Image) {
		if (_Image == null || _Image.equals("")) {
			return 0;
		}
		byte[] bitImage = Base64.decodeBase64(_Image);
		// ki?m tra xem c� thu m?c ch?a h�nh hay chua => t?o
		String tomcatDir = System.getProperty("catalina.home");
		File file = new File(tomcatDir + NON_RESIDENT_IMAGE_DIR_IDENTITY_CARD);
		if (!file.exists()) {
			file.mkdir();
		}

		// Tach folder ra theo yyyy-mm de quan ly trong
		// NON_RESIDENT_IMAGE_DIR_IDENTITY_CARD
		File fileChild = new File(
				tomcatDir + NON_RESIDENT_IMAGE_DIR_IDENTITY_CARD + "//" + NON_RESIDENT_IMAGE_DIR_IDENTITY_CARD_CHILD);
		if (!fileChild.exists()) {
			fileChild.mkdir();
		}

		BufferedImage bufferedImage = null;
		ByteArrayInputStream bais = new ByteArrayInputStream(bitImage);
		try {
			bufferedImage = ImageIO.read(bais);
		} catch (IOException e1) {
			e1.printStackTrace();
		}
		File fileImg = new File(tomcatDir + NON_RESIDENT_IMAGE_DIR_IDENTITY_CARD + "//"
				+ NON_RESIDENT_IMAGE_DIR_IDENTITY_CARD_CHILD + "//" + imageId + ".jpg");
		try {
			ImageIO.write(bufferedImage, "jpg", fileImg);
			return imageId;
		} catch (IOException e) {
			e.printStackTrace();
		}
		// l?i kh�ng th�m dc h�nh
		return 0;
	}

	/**
	 * 
	 * @param imageId
	 *            se trung voi NonResidentId
	 * @return "" la loi
	 */
	@Override
	public String getImageIdentityCard(long imageId) {
		String tomcatDir = System.getProperty("catalina.home");
		File fi = new File(tomcatDir + NON_RESIDENT_IMAGE_DIR_IDENTITY_CARD + "//"
				+ NON_RESIDENT_IMAGE_DIR_IDENTITY_CARD_CHILD + "//" + imageId + ".jpg");
		if (fi.exists()) { // ki?m tra du?ng d?n
			byte[] bitImage = null;
			try {
				bitImage = Files.readAllBytes(fi.toPath());
			} catch (IOException e) {
				e.printStackTrace();
			}
			try {
				return Base64.encodeBase64String(bitImage);
			} catch (Exception ex) {
				// l?i kh�ng l?y du?c h�nh
			}
		}
		return "";
	}

}
