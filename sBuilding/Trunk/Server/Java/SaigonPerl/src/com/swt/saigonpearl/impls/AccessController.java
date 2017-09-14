package com.swt.saigonpearl.impls;

//import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import com.swt.saigonpearl.IPersonalizationDevice;
import com.swt.saigonpearl.domain.DoorIn;
import com.swt.saigonpearl.domain.DoorOut;
import com.swt.saigonpearl.domain.PersonalizationDevice;
//import com.swt.saigonpearl.domain.ManagerCosts;
import com.swt.sworld.cms.domain.CardChip;
import com.swt.sworld.cms.impls.CardChipController;
import com.swt.sworld.common.domain.Config;
import com.swt.sworld.common.impls.ConfigDAOImpl;
import com.swt.sworld.device.domain.DeviceDoor;
import com.swt.sworld.device.impls.DeviceDoorController;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.ChipPersonalizationController;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.sworld.utilites.SworldConst;
//import com.swt.timekeeping.domain.Shift;
//import com.swt.timekeeping.impls.TimeKeepingShiftController;

public class AccessController {
	
	public static final AccessController Instance = new AccessController();
	private ConfigDAOImpl confObj = new ConfigDAOImpl();
	private IPersonalizationDevice personalizationDeviceDAO = new PersonalizationDeviceDAO();
	
	public Config getConfigByName()
	{
		return confObj.getValueByName(SworldConst.TOTAL_MONTHLY_DEBT);
	}
	
	public Config insertConfig(String value)
	{
		Config temp = new Config();
		temp.setName(SworldConst.TOTAL_MONTHLY_DEBT);
		temp.setValue(value);
		temp.setStatus(1);
		return confObj.addConfig(temp);
	}
	
	public Config updateConfig(Config config)
	{
		return confObj.updateConfig(config);
	}
	
	public int validateCardStatus(String serialNumber)
	{
		int status = SworldConst.NORMAL;
		ChipPersonalization chipPer = ChipPersonalizationController.Instance.getBySerial(serialNumber);
		CardChip cardChip = CardChipController.Instance.getBySerialNumber(serialNumber);
		if(cardChip != null)
		{
			switch (cardChip.getPhysicalStatus()) {
				case SworldConst.MARKBROKEN:
					return SworldConst.MARKBROKEN;
				case SworldConst.MARKLOST:
					return SworldConst.MARKLOST;
				default:
					status = SworldConst.NORMAL;
					break;
			}
		}
//		else
//			return SworldConst.NOTCARDSYSTEM;
		if(chipPer != null)
		{
			//Kiem tra tinh trang luot phat hanh
			switch (chipPer.getStatus()) {
				case SworldConst.LOCK:
					return SworldConst.LOCK;
				case SworldConst.CANCEL:
					return SworldConst.CANCEL;
				default:
					status = SworldConst.NORMAL;
					break;
			}
		}
		else
			return SworldConst.NOT_PERSO;
		return status;
	}
	
	public DoorOut AccessProcess(String ip,DoorOut doorOut)
	{
//		SimpleDateFormat dateFormat = new SimpleDateFormat("dd-MM-yyyy");
//		int totalMonthlyDebt = Integer.parseInt(confObj.getValueActive(SworldConst.TOTAL_MONTHLY_DEBT));
		
		if(validateCardStatus(doorOut.getSerialNumber()) == SworldConst.NORMAL && doorOut != null)
		{
			ChipPersonalization chipper = ChipPersonalizationController.Instance.getBySerial(doorOut.getSerialNumber());
			DeviceDoor device= DeviceDoorController.Instance.getDeviceDoorByIp(ip);
			CardChip card = CardChipController.Instance.getBySerialNumber(doorOut.getSerialNumber());
			Member member = MemberController.Instance.getMemberById(chipper.getPsMemberId());
			System.out.println(member.getSubOrgId());
//			ManagerCosts mc = ManagerCostsController.Instance.getManagerCostBySubOrgId(member.getSubOrgId());
			
//			if((totalMonthlyDebt >= getDaysInMonth(mc != null? mc.getDayPay() : dateFormat.format(new Date()))
//					&& member.getOrgCode().equals(device.getPort())) || member.getOrgCode().equals("0001"))
//			{
				//Hop le thi xu ly
				DoorIn doorIn = DoorInController.Instance.getDoorInBySerialNumber(doorOut.getSerialNumber(), device.getId());
				if(doorIn == null)
				{
					doorIn = insertDoorIn(doorOut,device.getId(),card.getCardChipId(),member.getId());
					doorOut = insertDoorOut(doorIn);
					
				}
				else 
				{
					doorOut = updateDoorOut(doorOut, device.getId());
					DoorInController.Instance.delete(doorIn.getId());
				}

		}
		return doorOut;
	}
	public DoorOut AccessProcessNomal(String ip, DoorOut doorOut) {
//		SimpleDateFormat dateFormat = new SimpleDateFormat("dd-MM-yyyy");
//		int totalMonthlyDebt = Integer.parseInt(confObj
//				.getValueActive(SworldConst.TOTAL_MONTHLY_DEBT));

		if (validateCardStatus(doorOut.getSerialNumber()) == SworldConst.NORMAL
				&& doorOut != null) {
			ChipPersonalization chipper = ChipPersonalizationController.Instance
					.getBySerial(doorOut.getSerialNumber());
			DeviceDoor device = DeviceDoorController.Instance
					.getDeviceDoorByIp(ip);
			CardChip card = CardChipController.Instance
					.getBySerialNumber(doorOut.getSerialNumber());
			Member member = MemberController.Instance.getMemberById(chipper
					.getPsMemberId());
			System.out.println(member.getSubOrgId());

			List<PersonalizationDevice> lstpersionalDevice = personalizationDeviceDAO
					.getListPersonalizationDevices(ip,
							doorOut.getSerialNumber());
			if (lstpersionalDevice.size()>0) {
				// Hop le thi xu ly
				DoorIn doorIn = DoorInController.Instance
						.getDoorInBySerialNumber(doorOut.getSerialNumber(),
								device.getId());
				if (doorIn == null) {
					doorIn = insertDoorIn(doorOut, device.getId(),
							card.getCardChipId(), member.getId());
					doorOut = insertDoorOut(doorIn);

				} else {
					doorOut = updateDoorOut(doorOut, device.getId());
					DoorInController.Instance.delete(doorIn.getId());
				}
			}
		}
		return doorOut;
	}
	
	private int daysBetween(Date d1, Date d2){
        return (int)( (d2.getTime() - d1.getTime()) / (1000 * 60 * 60 * 24));
	}
	public int getDaysInMonth(String date)
	{
		SimpleDateFormat dateFormat = new SimpleDateFormat("dd-MM-yyyy");
		int days = 0;
		try {
			days = daysBetween(dateFormat.parse(date),new Date());
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	    return days;
	}
	
	
	private DoorOut insertDoorOut(DoorIn doorIn)
	{
		DoorOut doorOut = new DoorOut();
		doorOut.setDeviceDoorId(doorIn.getDeviceDoorId());
		doorOut.setCardId(doorIn.getCardId());
		doorOut.setMemberId(doorIn.getMemberId());
		doorOut.setSerialNumber(doorIn.getSerialNumber());
		doorOut.setImageIn(doorIn.getImageIn());
		doorOut.setDateIn(doorIn.getDateIn());
		doorOut.setStatus(SworldConst.Process);
		return DoorOutController.Instance.insert(doorOut);
	}
	
	private DoorIn insertDoorIn(DoorOut doorOut,long deviceId, long cardId, long memberId)
	{
		DoorIn doorIn = new DoorIn();
		doorIn.setDeviceDoorId(deviceId);
		doorIn.setCardId(cardId);
		doorIn.setMemberId(memberId);
		doorIn.setSerialNumber(doorOut.getSerialNumber());
		doorIn.setImageIn(doorOut.getImageIn());
		doorIn.setDateIn(doorOut.getDateIn());
		
		return DoorInController.Instance.insert(doorIn);
	}
	
	private DoorOut updateDoorOut(DoorOut doorOut, long deviceId)
	{
		DoorOut doorOutDB = DoorOutController.Instance.getDoorOutBySerialNumber(doorOut.getSerialNumber(),deviceId, SworldConst.Process);
		if(doorOutDB!= null)
		{
			doorOutDB.setImageOut(doorOut.getImageOut());
			doorOutDB.setDateOut(doorOut.getDateOut());
			doorOutDB.setStatus(SworldConst.Success);
		}
		return DoorOutController.Instance.update(doorOutDB);
	}
}
