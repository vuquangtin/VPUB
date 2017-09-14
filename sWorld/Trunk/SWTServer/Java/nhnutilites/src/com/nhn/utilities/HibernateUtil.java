/**
 * 
 */
package com.nhn.utilities;

import java.io.File;

import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.AnnotationConfiguration;

import com.nhn.error.ErrorCodeSworld;


/**
 * Class giao tiếp với db thông qua hibernate
 * @author votinh
 *
 */
public class HibernateUtil {
	private static String filecon = null;
	private static SessionFactory sessionFactory = buildSessionFactory();
	private static SessionFactory buildSessionFactory()
	{
		try {
			if (null == filecon || "".equals(filecon))
				filecon =  "hibernate.cfg.xml";
			
			@SuppressWarnings("unused")
			File file = new File(filecon);
			return new AnnotationConfiguration().configure().buildSessionFactory();
			
		} catch (Throwable ex) {
			// Make sure you log the exception, as it might be swallowed
			System.err.println("Initial SessionFactory creation failed." + ex);
			throw new ExceptionInInitializerError(ex);
		}
	}
	/**
	 * Thiết lập đường dẫn file config đến db
	 * @param filename : đường dẫn của file config
	 */
	public static void setConnectionFile(String filepath)
	{
		filecon = filepath;
	}
	
	/**
	 * Tạo ra một session factory 
	 * @return session factory
	 */
	public static SessionFactory getSessionFactory() {
		return sessionFactory;
	}
 
	/**
	 * Tạo ra một session 
	 * @return session
	 */
	public static Session getSession()
	{
		Session session = null;
		try{
			if(sessionFactory.isClosed()){
				sessionFactory = buildSessionFactory();
			}
			session = sessionFactory.openSession();
		}catch (Exception e) {
			sessionFactory = buildSessionFactory();
			session = sessionFactory.openSession();
		}

		return session;
	}
	
	/**
	 * Đóng session factory đã tạo ra trước đó
	 */
	public static void close() {
		// Close caches and connection pools
		getSessionFactory().close();
	}
	
	/**
	 * Chỉ cho phép cập nhật một record (entity, đối tượng) vào db
	 * @param entity : đối tượng cần cập nhậ vào db
	 * @return kết quả trả về mã cho biết thành công hay thất bại
	 */
	public static <T>  int update(T entity) {
 		Session session = getSession();
		int result = ErrorCodeSworld.OPEN_TRANSACTION_FALSED;
		try {
			session.getTransaction().begin();
			session.update(entity);
			session.getTransaction().commit();

			result = ErrorCodeSworld.SUCCESS;

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
	 * Cho phép thêm mới một record (entity, đối tượng nếu chưa tồn tại trong db) hoặc cập nhật thông tin của một record 
	 * @param entity: đối tượng cần thêm mới hoặc cập nhật
	 * @return kết quả trả về một đối tượng
	 */
	public static <T> T updateObject(T entity) {
		Session session = getSession();
		try {
			session.getTransaction().begin();
			session.saveOrUpdate(entity);
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return entity;
	}

	/**
	 * Cho phép thêm mới một record (entity, đối tượng nếu chưa tồn tại trong db)
	 * @param entity: đối tượng cần thêm mới hoặc cập nhật
	 * @return kết quả trả về mã cho biết thành công hay thất bại
	 */
	public static <T> int insert(T entity) {
		Session session = getSession();
		int result = ErrorCodeSworld.OPEN_TRANSACTION_FALSED;
		try {
			session.getTransaction().begin();
			session.save(entity);
			session.getTransaction().commit();

			result = ErrorCodeSworld.SUCCESS;

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
	 * Cho phép thêm mới một record (entity, đối tượng nếu chưa tồn tại trong db)
	 * @param entity: đối tượng cần thêm mới hoặc cập nhật
	 * @return kết quả trả về một đối tượng
	 */
	public static <T> T insertObject(T entity) {
		Session session = getSession();
		try {
			session.getTransaction().begin();
			session.saveOrUpdate(entity);
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return entity;
	}
	
	/**
	 * Xóa một đối tượng trong db theo id của nó
	 * @param entity: tên của đối Entity tương ứng cần xóa
	 * @param id: id của record cần xóa
	 * @return kết quả trả về một mã
	 */
	public static <T> int deleteById(T entity, long id) {
		Session session = getSession();
		int result = ErrorCodeSworld.OPEN_TRANSACTION_FALSED;
		try {
			session.getTransaction().begin();
			Object config = session.get(entity.getClass(), id);
			if(null == config)
				result = ErrorCodeSworld.NOT_FOUND_OBJ;
			else
			{
				session.delete(config);
				session.getTransaction().commit();
				
				result = ErrorCodeSworld.SUCCESS;
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

}
