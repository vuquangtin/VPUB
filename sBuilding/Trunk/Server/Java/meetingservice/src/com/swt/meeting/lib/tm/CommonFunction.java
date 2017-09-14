package com.swt.meeting.lib.tm;

import java.util.List;
import java.util.Map;

import org.hibernate.Criteria;
import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.criterion.Order;
import org.hibernate.criterion.Projections;
import org.hibernate.criterion.Restrictions;

import com.nhn.utilities.HibernateUtil;

public class CommonFunction {
	public static final CommonFunction INSTANCE = new CommonFunction();

	private CommonFunction() {

	}

	public Object getListDataByQuery(String stringQuery, List<String> keys, Map<String, Object> mapValue,
			List<String> groupBys, List<String> orderBys) {
		Session session = HibernateUtil.getSession();
		Object result = null;
		try {
			session.getTransaction().begin();
			for (String group : groupBys) {
				stringQuery += " " + group + " ";
			}
			for (String orderBy : orderBys) {
				stringQuery += " " + orderBy + " ";
			}
			Query query = session.createSQLQuery(stringQuery);
			for (String key : keys) {
				query.setParameter(key, mapValue.get(key).toString());
			}
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

	public Object getOnlyOneDataByQuery(String stringQuery, List<String> keys, Map<String, Object> mapValue,
			List<String> groupBys, List<String> orderBys) {
		Session session = HibernateUtil.getSession();
		Object result = null;
		try {
			session.getTransaction().begin();
			if (groupBys != null) {
				for (String group : groupBys) {
					stringQuery += " " + group + " ";
				}
			}

			if (orderBys != null) {
				for (String orderBy : orderBys) {
					stringQuery += " " + orderBy + " ";
				}
			}
			Query query = session.createSQLQuery(stringQuery);

			for (String key : keys) {
				query.setParameter(key, mapValue.get(key).toString());
			}

			result = query.uniqueResult();

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

	public Object getListDataByProcedure(String stringQuery, List<String> keys, Map<String, Object> mapValue,
			List<String> groupBys, List<String> orderBys) {
		Session session = HibernateUtil.getSession();
		Object result = null;
		try {
			session.getTransaction().begin();
			if (groupBys != null) {
				for (String group : groupBys) {
					stringQuery += " " + group + " ";
				}
			}

			if (orderBys != null) {
				for (String orderBy : orderBys) {
					stringQuery += " " + orderBy + " ";
				}
			}
			Query query = session.getNamedQuery(stringQuery);
			for (String key : keys) {
				query.setParameter(key, mapValue.get(key).toString());
			}
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

	public Object getOnlyOneDataByProcedure(String stringQuery, List<String> keys, Map<String, Object> mapValue,
			List<String> groupBys, List<String> orderBys) {
		Session session = HibernateUtil.getSession();
		Object result = null;
		try {
			session.getTransaction().begin();
			if (groupBys != null) {
				for (String group : groupBys) {
					stringQuery += " " + group + " ";
				}
			}

			if (orderBys != null) {
				for (String orderBy : orderBys) {
					stringQuery += " " + orderBy + " ";
				}
			}
			Query query = session.getNamedQuery(stringQuery);

			for (String key : keys) {
				query.setParameter(key, mapValue.get(key).toString());
			}
			result = query.uniqueResult();

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

	// -------------------------------------------
	private Object table;

	public void setTable(Object object) {
		this.table = object;
	}

	public Object insert(Object object) {
		Session session = HibernateUtil.getSession();
		session.saveOrUpdate(object);
		session.flush();
		session.clear();
		session.close();
		return object;
	}

	public Object update(Object object) {
		Session session = HibernateUtil.getSession();
		session.saveOrUpdate(object);
		session.flush();
		session.clear();
		session.close();
		return object;
	}

	public void delete(long id) {
		Session session = HibernateUtil.getSession();
		session.delete(getById(id));
		session.flush();
		session.clear();
		session.close();
	}

	public Object getAll() {
		Session session = HibernateUtil.getSession();
		Object result = session.createCriteria(table.getClass()).list();
		session.flush();
		session.clear();
		session.close();
		return result;
	}

	public Object getById(long id) {
		Session session = HibernateUtil.getSession();
		Object result = session.get(table.getClass(), id);
		session.flush();
		session.clear();
		session.close();
		return result;
	}

	public Object getByCriteria(List<TMCondition> conditions) {
		Session session = HibernateUtil.getSession();
		Object result = null;
		try {
			Criteria c = session.createCriteria(this.table.getClass());
			for (TMCondition tmCondition : conditions) {
				if (tmCondition.getComparisonType().equals("eq")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("eqnumberic")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("eqboolean")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), Boolean.parseBoolean(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("like")) {
					c.add(Restrictions.like(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("gt")) {
					c.add(Restrictions.gt(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("lt")) {
					c.add(Restrictions.lt(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("gtnumberic")) {
					c.add(Restrictions.gt(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("ltnumberic")) {
					c.add(Restrictions.lt(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("between")) {
					String[] values = tmCondition.getValue().split(",");
					String value1 = values[0];
					String value2 = values[1];
					c.add(Restrictions.between(tmCondition.getColumnName(), value1, value2));
				} else if (tmCondition.getComparisonType().equals("isNull")) {
					c.add(Restrictions.isNull(tmCondition.getColumnName()));
				} else if (tmCondition.getComparisonType().equals("isNotNull")) {
					c.add(Restrictions.isNotNull(tmCondition.getColumnName()));
				} else if (tmCondition.getComparisonType().equals("isNotEmpty")) {
					c.add(Restrictions.isNotEmpty(tmCondition.getColumnName()));
				}
			}
			result = c.list();

		} catch (Exception e) {
			System.out.println(e);
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	public Object getByCriteriaLimit(List<TMCondition> conditions, long start, long limit) {
		Session session = HibernateUtil.getSession();
		Object result = null;
		try {
			Criteria c = session.createCriteria(this.table.getClass());

			for (TMCondition tmCondition : conditions) {
				if (tmCondition.getComparisonType().equals("eq")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("eqnumberic")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("eqboolean")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), Boolean.parseBoolean(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("like")) {
					c.add(Restrictions.like(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("gt")) {
					c.add(Restrictions.gt(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("lt")) {
					c.add(Restrictions.lt(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("gtnumberic")) {
					c.add(Restrictions.gt(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("ltnumberic")) {
					c.add(Restrictions.lt(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("between")) {
					String[] values = tmCondition.getValue().split(",");
					String value1 = values[0];
					String value2 = values[1];
					c.add(Restrictions.between(tmCondition.getColumnName(), value1, value2));
				} else if (tmCondition.getComparisonType().equals("isNull")) {
					c.add(Restrictions.isNull(tmCondition.getColumnName()));
				} else if (tmCondition.getComparisonType().equals("isNotNull")) {
					c.add(Restrictions.isNotNull(tmCondition.getColumnName()));
				} else if (tmCondition.getComparisonType().equals("isNotEmpty")) {
					c.add(Restrictions.isNotEmpty(tmCondition.getColumnName()));
				}
			}
			c.setFirstResult((int) start);
			c.setMaxResults((int) limit);

			result = c.list();

		} catch (Exception e) {
			System.out.println(e);
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	public Object getByCriteriaOrderBy(TMConditionAndOrderBy conditionAndOrderBies) {
		Session session = HibernateUtil.getSession();
		Object result = null;
		try {
			Criteria c = session.createCriteria(this.table.getClass());
			List<TMCondition> conditions = conditionAndOrderBies.getConditions();

			for (TMCondition tmCondition : conditions) {
				if (tmCondition.getComparisonType().equals("eq")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("eqnumberic")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("eqboolean")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), Boolean.parseBoolean(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("like")) {
					c.add(Restrictions.like(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("gt")) {
					c.add(Restrictions.gt(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("lt")) {
					c.add(Restrictions.lt(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("gtnumberic")) {
					c.add(Restrictions.gt(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("ltnumberic")) {
					c.add(Restrictions.lt(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("between")) {
					String[] values = tmCondition.getValue().split(",");
					String value1 = values[0];
					String value2 = values[1];
					c.add(Restrictions.between(tmCondition.getColumnName(), value1, value2));
				} else if (tmCondition.getComparisonType().equals("isNull")) {
					c.add(Restrictions.isNull(tmCondition.getColumnName()));
				} else if (tmCondition.getComparisonType().equals("isNotNull")) {
					c.add(Restrictions.isNotNull(tmCondition.getColumnName()));
				} else if (tmCondition.getComparisonType().equals("isNotEmpty")) {
					c.add(Restrictions.isNotEmpty(tmCondition.getColumnName()));
				}
			}

			List<TMOrderBy> tmOrderBies = conditionAndOrderBies.getOrderBies();
			for (TMOrderBy tmOrderBy : tmOrderBies) {
				if (tmOrderBy.isASC()) {
					c.addOrder(Order.asc(tmOrderBy.getColumnName()));
				} else {
					c.addOrder(Order.desc(tmOrderBy.getColumnName()));
				}

			}
			result = c.list();

		} catch (Exception e) {
			System.out.println(e);
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	public Object getByCriteriaOrderByLimit(TMConditionAndOrderBy conditionAndOrderBies, int start, int limit) {
		Session session = HibernateUtil.getSession();
		Object result = null;
		try {
			Criteria c = session.createCriteria(this.table.getClass());
			List<TMCondition> conditions = conditionAndOrderBies.getConditions();

			for (TMCondition tmCondition : conditions) {
				if (tmCondition.getComparisonType().equals("eq")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("eqnumberic")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("eqboolean")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), Boolean.parseBoolean(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("like")) {
					c.add(Restrictions.like(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("gt")) {
					c.add(Restrictions.gt(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("lt")) {
					c.add(Restrictions.lt(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("gtnumberic")) {
					c.add(Restrictions.gt(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("ltnumberic")) {
					c.add(Restrictions.lt(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("between")) {
					String[] values = tmCondition.getValue().split(",");
					String value1 = values[0];
					String value2 = values[1];
					c.add(Restrictions.between(tmCondition.getColumnName(), value1, value2));
				} else if (tmCondition.getComparisonType().equals("isNull")) {
					c.add(Restrictions.isNull(tmCondition.getColumnName()));
				} else if (tmCondition.getComparisonType().equals("isNotNull")) {
					c.add(Restrictions.isNotNull(tmCondition.getColumnName()));
				} else if (tmCondition.getComparisonType().equals("isNotEmpty")) {
					c.add(Restrictions.isNotEmpty(tmCondition.getColumnName()));
				}
			}

			List<TMOrderBy> tmOrderBies = conditionAndOrderBies.getOrderBies();
			for (TMOrderBy tmOrderBy : tmOrderBies) {
				if (tmOrderBy.isASC()) {
					c.addOrder(Order.asc(tmOrderBy.getColumnName()));
				} else {
					c.addOrder(Order.desc(tmOrderBy.getColumnName()));
				}

			}

			c.setFirstResult(start);
			c.setMaxResults(limit);
			result = c.list();

		} catch (Exception e) {
			System.out.println(e);
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	public long sumByCriteria(List<TMCondition> conditions) {
		Session session = HibernateUtil.getSession();
		long result = 0;
		try {
			Criteria c = session.createCriteria(this.table.getClass());
			c.setProjection(Projections.rowCount());

			for (TMCondition tmCondition : conditions) {
				if (tmCondition.getComparisonType().equals("eq")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("eqnumberic")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("eqboolean")) {
					c.add(Restrictions.eq(tmCondition.getColumnName(), Boolean.parseBoolean(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("like")) {
					c.add(Restrictions.like(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("gt")) {
					c.add(Restrictions.gt(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("lt")) {
					c.add(Restrictions.lt(tmCondition.getColumnName(), tmCondition.getValue()));
				} else if (tmCondition.getComparisonType().equals("gtnumberic")) {
					c.add(Restrictions.gt(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("ltnumberic")) {
					c.add(Restrictions.lt(tmCondition.getColumnName(), Long.parseLong(tmCondition.getValue())));
				} else if (tmCondition.getComparisonType().equals("between")) {
					String[] values = tmCondition.getValue().split(",");
					String value1 = values[0];
					String value2 = values[1];
					c.add(Restrictions.between(tmCondition.getColumnName(), value1, value2));
				} else if (tmCondition.getComparisonType().equals("isNull")) {
					c.add(Restrictions.isNull(tmCondition.getColumnName()));
				} else if (tmCondition.getComparisonType().equals("isNotNull")) {
					c.add(Restrictions.isNotNull(tmCondition.getColumnName()));
				} else if (tmCondition.getComparisonType().equals("isNotEmpty")) {
					c.add(Restrictions.isNotEmpty(tmCondition.getColumnName()));
				}
			}
			result = (long) c.uniqueResult();

		} catch (Exception e) {
			System.out.println(e);
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	public Object getBySqlQuery(String sql) {
		Session session = HibernateUtil.getSession();

		Object result = null;
		try {
			session.getTransaction().begin();
			Query query = session.createSQLQuery(sql);
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

	public Object executeUpdateBySqlQuery(String sql) {
		Session session = HibernateUtil.getSession();

		Object result = null;
		try {
			session.getTransaction().begin();
			Query query = session.createQuery(sql);
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

	public Object getByNameProcedure(String nameProcedure, List<String> keys, Map<String, String> paras) {
		Session session = HibernateUtil.getSession();

		Object result = null;
		try {
			session.getTransaction().begin();
			Query query = session.getNamedQuery(nameProcedure);
			for (String key : keys) {
				query.setParameter(key, paras.get(key));
			}
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

	public Object getByQuery(String sql) {
		Session session = HibernateUtil.getSession();

		Object result = null;
		try {
			session.getTransaction().begin();
			Query query = session.createQuery(sql);
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

	public long sumByQuery(String sql) {
		Session session = HibernateUtil.getSession();

		long result = 0;
		try {
			session.getTransaction().begin();
			Query query = session.createQuery(sql);
			System.out.println((query.uniqueResult()).toString());
			result = Long.parseLong(query.uniqueResult().toString());
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

	public Object getOnlyByQuery(String sql) {
		Session session = HibernateUtil.getSession();

		Object result = null;
		try {
			session.getTransaction().begin();
			Query query = session.createQuery(sql);
			result = query.uniqueResult();
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
