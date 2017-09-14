package com.swt.timekeeping.customer.object;

public class GeneralConfigJson {
	private GeneralConfigTime cardTag;
	private GeneralConfigTime late;
	private GeneralConfigTime lateHalfDay;

	public GeneralConfigJson() {

	}

	public GeneralConfigJson(GeneralConfigTime cardTag, GeneralConfigTime late, GeneralConfigTime lateHalfDay) {
		this.cardTag = cardTag;
		this.late = late;
		this.lateHalfDay = lateHalfDay;
	}

	public GeneralConfigTime getCardTag() {
		return cardTag;
	}

	public void setCardTag(GeneralConfigTime cardTag) {
		this.cardTag = cardTag;
	}

	public GeneralConfigTime getLate() {
		return late;
	}

	public void setLate(GeneralConfigTime late) {
		this.late = late;
	}

	public GeneralConfigTime getLateHalfDay() {
		return lateHalfDay;
	}

	public void setLateHalfDay(GeneralConfigTime lateHalfDay) {
		this.lateHalfDay = lateHalfDay;
	}
}
