/**
 * 
 */
package com.swt.sworld.ps.impl;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.communication.customer.object.PersoChipFilter;
import com.swt.sworld.ps.IChipPersonalizationDAO;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.utilites.SworldConst;

/**
 * @author loc.le
 * 
 */
public class ChipPersonalizationDAOImpl implements IChipPersonalizationDAO {

	@Override
	public int update(ChipPersonalization chipper) {
		return HibernateUtil.update(chipper);
	}

	@Override
	public long updateStatus(long chipersoid, String resion, int status) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE ChipPersonalization SET Notes=:resion, Status=:status WHERE ChipPersoId=:chipersoid";
			Query query = session.createQuery(strQuery);
			query.setParameter("chipersoid", chipersoid);
			query.setParameter("resion", resion);
			query.setParameter("status", status);
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

		return chipersoid;
	}

	@Override
	public int update(long memberId, String serialNumber) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		try {
			session.getTransaction().begin();
			ChipPersonalization pscp = (ChipPersonalization) session.get(
					ChipPersonalization.class, memberId);
			pscp.setSerialNumber(serialNumber);
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return 0;
	}

	@Override
	public int getPersoIdByCardChipId(byte[] serialNumber) {

		return 0;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<ChipPersonalization> getChipPersoByMemberId(long memberid) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		List<ChipPersonalization> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ChipPersonalization WHERE PsMemberId = :memberid";
			Query query = session.createQuery(strQuery);
			query.setParameter("memberid", memberid);

			result = query.list();

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

	// Loc lam
	public int getStatusByChipersoId(long chipersoid, int status) {
		int result = 0;
		Session session = HibernateUtil.getSessionFactory().openSession();

		ChipPersonalization cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ChipPersonalization WHERE ChipPersoId = :chipersoid AND Status = :status";
			Query query = session.createQuery(strQuery);
			query.setParameter("chipersoid", chipersoid);
			query.setParameter("status", status);
			cp = (ChipPersonalization) query.uniqueResult();
			session.getTransaction().commit();
			if (cp == null) {
				return result;
			}
			result = cp.getStatus();
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

	// @Override
	// public long cancelPersoByChipPersoId(long chipersoid, String
	// cancelreason) {
	//
	// Session session = HibernateUtil.getSessionFactory().openSession();
	// TransactionMerchant transaction = null;
	// try {
	// session.getTransaction().begin();
	// String strQuery =
	// "UPDATE ChipPersonalization SET Notes=:cancelreason, Status=:cancel WHERE ChipPersoId=:chipersoid";
	// Query query = session.createQuery(strQuery);
	// query.setParameter("chipersoid", chipersoid);
	// query.setParameter("cancelreason", cancelreason);
	// query.setParameter("cancel", StatusCardChip.CANCEL);
	// query.executeUpdate();
	// session.getTransaction().commit();
	// } catch (HibernateException e) {
	// session.getTransaction().rollback();
	// e.printStackTrace();
	// } finally {
	// session.close();
	// }
	//
	// return chipersoid;
	// }

	// @Override
	// public long lockPersoByChipPersoId(long chipersoid, String lockreason) {
	//
	// Session session = HibernateUtil.getSessionFactory().openSession();
	// TransactionMerchant transaction = null;
	// try {
	// session.getTransaction().begin();
	// String strQuery =
	// "UPDATE ChipPersonalization SET Notes=:lockreason, Status=:lock WHERE ChipPersoId=:chipersoid";
	// Query query = session.createQuery(strQuery);
	// query.setParameter("chipersoid", chipersoid);
	// query.setParameter("lockreason", lockreason);
	// query.setParameter("lock", StatusCardChip.LOCK);
	// query.executeUpdate();
	// session.getTransaction().commit();
	// } catch (HibernateException e) {
	// session.getTransaction().rollback();
	// e.printStackTrace();
	// } finally {
	// session.close();
	// }
	//
	// return chipersoid;
	// }

	// @Override
	// public long unlockPersoByChipPersoId(long chipersoid, String
	// unlockreason) {
	//
	// Session session = HibernateUtil.getSessionFactory().openSession();
	// TransactionMerchant transaction = null;
	// try {
	// session.getTransaction().begin();
	// String strQuery =
	// "UPDATE ChipPersonalization SET Notes=:unlockreason, Status=:unlock WHERE ChipPersoId=:chipersoid";
	// Query query = session.createQuery(strQuery);
	// query.setParameter("chipersoid", chipersoid);
	// query.setParameter("unlockreason", unlockreason);
	// query.setParameter("unlock", StatusCardChip.NORMAL);
	// query.executeUpdate();
	// session.getTransaction().commit();
	// } catch (HibernateException e) {
	// session.getTransaction().rollback();
	// e.printStackTrace();
	// } finally {
	// session.close();
	// }
	//
	// return chipersoid;
	// }

	@Override
	public long extendPersoByChipPersoId(long chipersoid, String expirationDate) {

		Session session = HibernateUtil.getSessionFactory().openSession();

		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE ChipPersonalization SET ExpirationDate=:expirationDate, Status=:extend WHERE ChipPersoId=:chipersoid";
			Query query = session.createQuery(strQuery);
			query.setParameter("chipersoid", chipersoid);
			query.setParameter("expirationDate", expirationDate);
			query.setParameter("extend", SworldConst.EXTEND);
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

		return chipersoid;

	}

	@Override
	public ChipPersonalization getChipPersoforPersoCus(long memid, PersoChipFilter filter) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		ChipPersonalization cp = null;
		try {
			String search = filter.clone();
			if (search == "") {
				session.getTransaction().begin();
				String strQuery = "FROM ChipPersonalization WHERE PsMemberId = :memid";
				Query query = session.createQuery(strQuery);
				query.setParameter("memid", memid);
				cp = (ChipPersonalization) query.uniqueResult();
			} else {
				session.getTransaction().begin();
				String strQuery = "FROM ChipPersonalization WHERE PsMemberId = :memid"
						+ search;
				Query query = session.createQuery(strQuery);
				query.setParameter("memid", memid);
				cp = (ChipPersonalization) query.uniqueResult();
			}
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return cp;
	}

	@Override
	public ChipPersonalization getMemberByIdAndSerial(long memberid,
			String serial) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		ChipPersonalization result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ChipPersonalization WHERE PsMemberId = :memberid AND SerialNumber = :serial";
			Query query = session.createQuery(strQuery);
			query.setParameter("memberid", memberid);
			query.setParameter("serial", serial);
			result = (ChipPersonalization) query.uniqueResult();

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
	public int ClearCardData(String serial) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		int result = 0;
		try {
			session.getTransaction().begin();
			String strQuery = "DELETE FROM ChipPersonalization WHERE SerialNumber = :serial";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", serial);
			result = query.executeUpdate();
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
	public ChipPersonalization persoCardChip(ChipPersonalization chipper) {

		Session session = HibernateUtil.getSessionFactory().openSession();

		ChipPersonalization result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ChipPersonalization WHERE SerialNumber = :serial";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", chipper.getSerialNumber());
			result = (ChipPersonalization) query.uniqueResult();
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
	public ChipPersonalization getCardChipBySerial(String serial) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		ChipPersonalization result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ChipPersonalization WHERE SerialNumber = :serial";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", serial);
			result = (ChipPersonalization) query.uniqueResult();

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
	public int update(String serial, String lastupdateDate, String NameUpdate) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		int result = 0;
		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE ChipPersonalization SET ModifiedOn=:lastupdateDate, ModifiedBy=:NameUpdate WHERE SerialNumber=:serial";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", serial);
			query.setParameter("lastupdateDate", lastupdateDate);
			query.setParameter("NameUpdate", NameUpdate);
			result = query.executeUpdate();
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
	public ChipPersonalization getChippersoByCardchipid(long cardchipid) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		ChipPersonalization cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ChipPersonalization WHERE CardChipId = :cardchipid";
			Query query = session.createQuery(strQuery);
			query.setParameter("cardchipid", cardchipid);
			cp = (ChipPersonalization) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return cp;
	}

	@Override
	public ChipPersonalization getChipPersoforPersoCusMember(long memid) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		ChipPersonalization cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ChipPersonalization WHERE PsMemberId = :memid";
			Query query = session.createQuery(strQuery);
			query.setParameter("memid", memid);
			cp = (ChipPersonalization) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return cp;
	}

	@Override
	public ChipPersonalization getPsMemberIdByChipPersoId(long chipperso) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		ChipPersonalization result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ChipPersonalization WHERE ChipPersoId = :chipperso";
			Query query = session.createQuery(strQuery);
			query.setParameter("chipperso", chipperso);
			result = (ChipPersonalization) query.uniqueResult();
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

	@SuppressWarnings("unchecked")
	@Override
	public List<ChipPersonalization> getall(long valueId) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		List<ChipPersonalization> result = null;
		try {
			if (valueId != 0) {
				session.getTransaction().begin();
				String strQuery = "FROM ChipPersonalization WHERE ChipPersoId > :valueId";
				Query query = session.createQuery(strQuery);
				query.setParameter("valueId", valueId);
				result = query.list();
				session.getTransaction().commit();
			} else {
				session.getTransaction().begin();
				String strQuery = "FROM ChipPersonalization";
				Query query = session.createQuery(strQuery);
				result = query.list();
				session.getTransaction().commit();
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

	@Override
	public ChipPersonalization getBySerial(String serial) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		ChipPersonalization result = new ChipPersonalization();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ChipPersonalization WHERE SerialNumber = :serial";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", serial);
			result = (ChipPersonalization) query.uniqueResult();
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
	public int deletePerso(long chipperso) {
		// TODO Auto-generated method stub
		ChipPersonalization chippersoDB = new ChipPersonalization();
		return HibernateUtil.deleteById(chippersoDB, chipperso);
	}
	
	@Override
	public long getPersoIdByCardChipId(String serialNumber){
		Session session = HibernateUtil.getSessionFactory().openSession();

		long result = 0;
		try {
			session.getTransaction().begin();
			String strQuery = "Select PsMemberId FROM ChipPersonalization WHERE SerialNumber = :serial AND Active= :active";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", serialNumber);
			query.setParameter("active", SworldConst.NORMAL);
			if(query.list().size() > 0)
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
	public ChipPersonalization getByMemberIdAndSerialNumber(
			long memberId, String serialNumber) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		ChipPersonalization result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ChipPersonalization WHERE PsMemberId = :memberId AND SerialNumber = :serial";
			Query query = session.createQuery(strQuery);
			query.setParameter("memberId", memberId);
			query.setParameter("serial", serialNumber);
			result = (ChipPersonalization) query.uniqueResult();
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
}
