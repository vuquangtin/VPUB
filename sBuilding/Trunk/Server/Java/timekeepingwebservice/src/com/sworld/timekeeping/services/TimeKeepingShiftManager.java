package com.sworld.timekeeping.services;

import java.awt.image.BufferedImage;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.imageio.ImageIO;
import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;

import org.apache.tomcat.util.codec.binary.Base64;
import org.codehaus.jettison.json.JSONException;
import org.codehaus.jettison.json.JSONObject;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.sworld.timekeeping.common.TimeKeepingDefines;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.timekeeping.customer.object.ShiftFilter;
import com.swt.timekeeping.customer.object.TimeKeepingImage;
import com.swt.timekeeping.domain.Shift;
import com.swt.timekeeping.impls.TimeKeepingShiftController;

/**
 * @author Trang Vo
 * 
 */
@Path(TimeKeepingDefines.TIMEKEEPINGSHIFTMANAGER)
@Produces(TimeKeepingDefines.APPLICATION_JSON)
public class TimeKeepingShiftManager {

	public static final String FORMAT_DATE = "yyyy-MM-dd HH:mm:ss";
	
	/**
	 * get doi tuong shift by shift id
	 * 
	 * @param session
	 * @param token
	 * @param timeKeepingShiftId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_SHIFT
			+ "/{token}/{timekeepingshiftid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getShiftByShiftId(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("timekeepingshiftid") long timeKeepingShiftId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			Shift shiftRequest = TimeKeepingShiftController.Instance
					.getTimeKeepingShiftById(timeKeepingShiftId);
			if (null != shiftRequest) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(shiftRequest);
		}
		return result;
	}

	/**
	 * get danh sach shift 1 lan/ 1 page
	 * 
	 * @param session
	 * @param token
	 * @param listMemberId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_SHIFT_LIST
			+ "/{token}/{datebegin}/{dateend}/{listmemberid}/{orgid}/{suborgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getShiftList(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("datebegin") String datebegin,
			@PathParam("dateend") String dateend, @PathParam("listmemberid") String listMemberId,
			@PathParam("orgid") long orgId, @PathParam("suborgid") long subOrgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			SimpleDateFormat dt = new SimpleDateFormat(FORMAT_DATE);
			try {
				Date dateBegin = dt.parse(datebegin);
				Date dateEnd = dt.parse(dateend);
				List<Shift> shiftRequest = TimeKeepingShiftController.Instance
						.getShift(dateBegin, dateEnd, listMemberId, orgId, subOrgId);
				if (null != shiftRequest) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
				result.setObj(shiftRequest);
			} catch (Exception e) {
				e.printStackTrace();
			}
			

		}
		return result;
	}

	/**
	 * lay danh sach shift by ShiftFilter
	 * 
	 * @param session
	 * @param token
	 * @param filters
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_SHIFT_LIST_BY_FILTER + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getShiftListByShiftFilter(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject filters) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			ShiftFilter filter = new ShiftFilter();
			SimpleDateFormat dt = new SimpleDateFormat(FORMAT_DATE);
			try {
				// set to filter
				filter.setFilterBySerialNumber(filters
						.getBoolean("FilterBySerialNumber"));
				filter.setSerialNumber(filters.getString("SerialNumber"));
				filter.setFilterByMemberId(filters
						.getBoolean("FilterByMemberId"));
				filter.setMemberId(filters.getLong("MemberId"));
				filter.setFilterByDeviceDoorId(filters
						.getBoolean("FilterByDeviceDoorId"));
				filter.setDeviceDoorId(filters.getLong("DeviceDoorId"));
				filter.setFilterByDeviceDoorIp(filters
						.getBoolean("FilterByDeviceDoorIp"));
				filter.setDeviceDoorIp(filters.getString("DeviceDoorIp"));
				filter.setFilterByDateIn(filters.getBoolean("FilterByDateIn"));
				filter.setDateIn(dt.parse(filters.getString("DateIn")));

				List<Shift> shiftRequest = TimeKeepingShiftController.Instance
						.getShiftListByShiftFilter(filter);
				if (null != shiftRequest) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
				result.setObj(shiftRequest);
			} catch (JSONException e) {
				e.printStackTrace();
			} catch (ParseException e) {
				e.printStackTrace();
			}

		}
		return result;
	}

	/**
	 * get ShiftImage By ShiftId
	 * 
	 * @param session
	 * @param token
	 * @param timeKeepingShiftId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.Get_SHIFT_IMAGE_BY_SHIFTID
			+ "/{token}/{timekeepingshiftid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getShiftImageByShiftId(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("timekeepingshiftid") long timeKeepingShiftId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			String tomcatDir = System.getProperty("catalina.home");
			File fi = new File(tomcatDir
					+ TimeKeepingDefines.TIMEKEEPING_IMAGE_DIR + "//"
					+ timeKeepingShiftId + ".jpg");
			if (fi.exists()) {
				byte[] bitImage = null;
				try {
					bitImage = Files.readAllBytes(fi.toPath());
				} catch (IOException e) {
					e.printStackTrace();
				}
				String sHinh = Base64.encodeBase64String(bitImage);

				if (null != bitImage) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
				result.setObj(new TimeKeepingImage(sHinh));
			}
		}
		return result;
	}

	/**
	 * insert ShiftImage
	 * 
	 * @param session
	 * @param token
	 * @param timeKeepingShiftId
	 * @param image
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.INSERT_SHIFT_IMAGE
			+ "/{token}/{timekeepingshiftid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertShiftImage(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token,
			@PathParam("timekeepingshiftid") long timeKeepingShiftId,
			JSONObject image) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			TimeKeepingImage imageRequest = new TimeKeepingImage();
			imageRequest = Utilites.getInstance().convertJsonObjToObject(image,
					imageRequest.getClass());
			byte[] bitImage = Base64.decodeBase64(imageRequest.getImage());

			// kiểm tra xem có thư mục chứa hình hay chưa => tạo
			String tomcatDir = System.getProperty("catalina.home");
			File file = new File(tomcatDir
					+ TimeKeepingDefines.TIMEKEEPING_IMAGE_DIR);
			if (!file.exists()) {
				file.mkdir();
			}

			BufferedImage bufferedImage = null;
			ByteArrayInputStream bais = new ByteArrayInputStream(bitImage);
			try {
				bufferedImage = ImageIO.read(bais);
			} catch (IOException e1) {
				e1.printStackTrace();
			}

			File fileImg = new File(tomcatDir
					+ TimeKeepingDefines.TIMEKEEPING_IMAGE_DIR + "//"
					+ timeKeepingShiftId + ".jpg");
			try {
				ImageIO.write(bufferedImage, "jpg", fileImg);
				result.setStatus(Status.SUCCESS);
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
		return result;
	}

	/**
	 * insert ShiftImage String
	 * @param session
	 * @param token
	 * @param timeKeepingShiftId
	 * @param _image
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.INSERT_SHIFT_IMAGE_STRING
			+ "/{token}/{timekeepingshiftid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertShiftImageString(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token,
			@PathParam("timekeepingshiftid") long timeKeepingShiftId,
			String _image) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			TimeKeepingImage imageRequest = new Gson().fromJson(_image,
					TimeKeepingImage.class);
			byte[] bitImage = Base64.decodeBase64(imageRequest.getImage());

			// kiểm tra xem có thư mục chứa hình hay chưa => tạo
			String tomcatDir = System.getProperty("catalina.home");
			File file = new File(tomcatDir
					+ TimeKeepingDefines.TIMEKEEPING_IMAGE_DIR);
			if (!file.exists()) {
				file.mkdir();
			}

			BufferedImage bufferedImage = null;
			ByteArrayInputStream bais = new ByteArrayInputStream(bitImage);
			try {
				bufferedImage = ImageIO.read(bais);
			} catch (IOException e1) {
				e1.printStackTrace();
			}

			File fileImg = new File(tomcatDir
					+ TimeKeepingDefines.TIMEKEEPING_IMAGE_DIR + "//"
					+ timeKeepingShiftId + ".jpg");
			try {
				ImageIO.write(bufferedImage, "jpg", fileImg);
				result.setStatus(Status.SUCCESS);
			} catch (IOException e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	/**
	 * insert Shift
	 * @param session
	 * @param token
	 * @param shift
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_SHIFT + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertShift(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, JSONObject shift) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			Shift shiftRequest = new Shift();

			GsonBuilder gsonBulider = new GsonBuilder();
			gsonBulider.setDateFormat(FORMAT_DATE);
			Gson gson = gsonBulider.create();
			shiftRequest = gson.fromJson(shift.toString(), Shift.class);
			shiftRequest.setDateIn(new Date());
			shiftRequest.setImageIn("");
			Member member = MemberController.Instance
					.getMemberByMemId(shiftRequest.getMemberId());
			shiftRequest.setOrgId(member.getOrgId());
			shiftRequest.setSubOrgId(member.getSubOrgId());
			Shift shiftDB = TimeKeepingShiftController.Instance
					.insert(shiftRequest);

			if (shiftDB != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(shiftDB);
		}

		return result;
	}

	/**
	 * insert Shift String
	 * @param session
	 * @param token
	 * @param _shift
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_SHIFT_STRING + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertShiftString(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, String _shift) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			Shift shiftRequest = new Shift();

			GsonBuilder gsonBulider = new GsonBuilder();
			gsonBulider.setDateFormat(FORMAT_DATE);
			Gson gson = gsonBulider.create();
			shiftRequest = gson.fromJson(_shift, Shift.class);
			shiftRequest.setDateIn(new Date());
			shiftRequest.setImageIn("");
			Member member = MemberController.Instance
					.getMemberByMemId(shiftRequest.getMemberId());
			shiftRequest.setOrgId(member.getOrgId());
			shiftRequest.setSubOrgId(member.getSubOrgId());
			Shift shiftDB = TimeKeepingShiftController.Instance
					.insert(shiftRequest);

			if (shiftDB != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(shiftDB);
		}

		return result;
	}

	/**
	 * update Shift
	 * @param session
	 * @param token
	 * @param shift
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.UPDATE_TIMEKEEPING_SHIFT + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject updateShift(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject shift) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			Shift shiftRequest = new Shift();

			shiftRequest = Utilites.getInstance().convertJsonObjToObject(shift,
					shiftRequest.getClass());
			Member member = MemberController.Instance
					.getMemberByMemId(shiftRequest.getMemberId());
			shiftRequest.setOrgId(member.getOrgId());
			shiftRequest.setSubOrgId(member.getSubOrgId());
			if (null != TimeKeepingShiftController.Instance
					.update(shiftRequest)) {
				result.setStatus(Status.SUCCESS);
				result.setObj(shiftRequest);
			}
		}
		return result;
	}

	/**
	 * delete Shift
	 * @param session
	 * @param token
	 * @param timeKeepingShiftId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.DELETE_TIMEKEEPING_SHIFT
			+ "/{token}/{timekeepingshiftid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject deleteShift(@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("timekeepingshiftid") long timeKeepingShiftId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			int kq = TimeKeepingShiftController.Instance
					.delete(timeKeepingShiftId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
}
