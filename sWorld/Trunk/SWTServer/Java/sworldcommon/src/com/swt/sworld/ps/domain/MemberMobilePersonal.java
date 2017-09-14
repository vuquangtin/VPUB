package com.swt.sworld.ps.domain;

public class MemberMobilePersonal {

	private long Id;
	
	private String LastName;
	
	private String FirstName;
	
	private int Gender;	
	
	private long memberid; // id của người được cấp thẻ
	
	private long mobilecardid; // id của thẻ được cấp. Id này có thể trùng nhau.

	private String serial; // số của thẻ được cấp

	private String qrcode; // số qr của thẻ được cấp
	
	private String barcode; // số barcode của thẻ được cấp
	
	private String telephone; // số của thẻ được cấp
	
	private String duration; // thời gian có hiệu lực của thẻ. (Thời gian hết hạn)
	
	private String content; // nội dung của thẻ. Theo một format nào đó. Sẽ được định nghĩa sau

	private String strimage; // image danh cho thẻ lưu ở dạng base64

	private String typecard; // loại thẻ (vd: thẻ quàn tặng, thẻ giảm giá, vourch-->Theo mã số hoặc theo tên gọi.

	private String card; // loại thẻ (vd: thẻ quàn tặng, thẻ giảm giá, vourch-->Theo mã số hoặc theo tên gọi.

	private String pin; // ping code
	
	private int status; // Trạng thái của thẻ

	public MemberMobilePersonal(long Id, String LastName, String FirstName, String telephone, int Gender, long memberid,  String qrcode, String barcode, String serial, String content, String typecard, String duration, int status){
		this.Id = Id;
		this.LastName=LastName;
		this.FirstName=FirstName;
		this.telephone=telephone;
		this.Gender=Gender;
		this.memberid=memberid;
		this.qrcode=qrcode;
		this.barcode=barcode;
		this.serial=serial;
		this.content=content;
		this.typecard=typecard;
		this.duration=duration;
		this.status=status;
	}
	
	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public String getLastName() {
		return LastName;
	}

	public void setLastName(String lastName) {
		LastName = lastName;
	}

	public String getFirstName() {
		return FirstName;
	}

	public void setFirstName(String firstName) {
		FirstName = firstName;
	}

	public int getGender() {
		return Gender;
	}

	public void setGender(int gender) {
		Gender = gender;
	}

	public long getMemberid() {
		return memberid;
	}

	public void setMemberid(long memberid) {
		this.memberid = memberid;
	}

	public long getMobilecardid() {
		return mobilecardid;
	}

	public void setMobilecardid(long mobilecardid) {
		this.mobilecardid = mobilecardid;
	}

	public String getSerial() {
		return serial;
	}

	public void setSerial(String serial) {
		this.serial = serial;
	}

	public String getQrcode() {
		return qrcode;
	}

	public void setQrcode(String qrcode) {
		this.qrcode = qrcode;
	}

	public String getBarcode() {
		return barcode;
	}

	public void setBarcode(String barcode) {
		this.barcode = barcode;
	}

	public String getTelephone() {
		return telephone;
	}

	public void setTelephone(String telephone) {
		this.telephone = telephone;
	}

	public String getDuration() {
		return duration;
	}

	public void setDuration(String duration) {
		this.duration = duration;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public String getStrimage() {
		return strimage;
	}

	public void setStrimage(String strimage) {
		this.strimage = strimage;
	}

	public String getTypecard() {
		return typecard;
	}

	public void setTypecard(String typecard) {
		this.typecard = typecard;
	}

	public String getCard() {
		return card;
	}

	public void setCard(String card) {
		this.card = card;
	}

	public String getPin() {
		return pin;
	}

	public void setPin(String pin) {
		this.pin = pin;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}
	
	
}
