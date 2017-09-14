package com.swt.meeting.lib.tm;

public class TMOrderBy {
	private String columnName;
	private boolean isASC;

	public TMOrderBy(String columnName, boolean isASC) {
		this.columnName = columnName;
		this.isASC = isASC;
	}

	public TMOrderBy() {
	}

	public String getColumnName() {
		return columnName;
	}

	public void setColumnName(String columnName) {
		this.columnName = columnName;
	}

	public boolean isASC() {
		return isASC;
	}

	public void setASC(boolean isASC) {
		this.isASC = isASC;
	}

}
