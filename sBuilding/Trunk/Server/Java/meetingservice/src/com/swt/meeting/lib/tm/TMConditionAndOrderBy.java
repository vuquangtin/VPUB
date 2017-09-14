package com.swt.meeting.lib.tm;

import java.util.List;

public class TMConditionAndOrderBy {
	private List<TMCondition> conditions;
	private List<TMOrderBy> orderBies;

	public TMConditionAndOrderBy(List<TMCondition> conditions, List<TMOrderBy> orderBies) {
		this.conditions = conditions;
		this.orderBies = orderBies;
	}

	public TMConditionAndOrderBy() {
	}

	public List<TMCondition> getConditions() {
		return conditions;
	}

	public void setConditions(List<TMCondition> conditions) {
		this.conditions = conditions;
	}

	public List<TMOrderBy> getOrderBies() {
		return orderBies;
	}

	public void setOrderBies(List<TMOrderBy> orderBies) {
		this.orderBies = orderBies;
	}

}
