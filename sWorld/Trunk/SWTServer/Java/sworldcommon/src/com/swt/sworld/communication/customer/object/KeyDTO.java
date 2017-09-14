package com.swt.sworld.communication.customer.object;

import java.io.Serializable;


public class KeyDTO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1823064003449626737L;

	private long Id;
	private long Alias;
	private String KeyValue;
	private SectorKeyPairDTO Key;

	public KeyDTO(long id, long seqid, String value1, SectorKeyPairDTO key)
	{
		this.Id =id;
		this.Alias =seqid;
		this.KeyValue = value1;
		this.Key=key;
	}

	public KeyDTO(long id, long seqid, String value1)
	{
		this.Id =id;
		this.Alias =seqid;
		this.setKeyValue(value1);
		this.Key=null;
	}
	
	public KeyDTO(long id, long seqid, SectorKeyPairDTO key)
	{
		this.Id =id;
		this.Alias =seqid;
		this.Key=key;
	}
	
	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public SectorKeyPairDTO getKey() {
		return Key;
	}

	public void setKey(SectorKeyPairDTO key) {
		Key = key;
	}

	public long getAlias() {
		return Alias;
	}

	public void setAlias(long alias) {
		Alias = alias;
	}

	public String getKeyValue() {
		return KeyValue;
	}

	public void setKeyValue(String keyValue) {
		KeyValue = keyValue;
	}
	
}
