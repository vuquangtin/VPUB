package com.swt.meeting.lib.tm;

public class TMCondition {
	private String ComparisonType;
	private String columnName;
	private String value;

	public TMCondition(String comparisonType, String columnName, String value) {
		ComparisonType = comparisonType;
		this.columnName = columnName;
		this.value = value;
	}

	public TMCondition() {
	}

	public String getComparisonType() {
		return ComparisonType;
	}

	public void setComparisonType(String comparisonType) {
		ComparisonType = comparisonType;
	}

	public String getColumnName() {
		return columnName;
	}

	public void setColumnName(String columnName) {
		this.columnName = columnName;
	}

	public String getValue() {
		return value;
	}

	public void setValue(String value) {
		this.value = value;
	}

}
