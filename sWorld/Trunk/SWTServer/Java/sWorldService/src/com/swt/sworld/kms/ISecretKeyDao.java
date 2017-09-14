package com.swt.sworld.kms;

import java.util.List;
import com.swt.sworld.kms.domain.SecretKey;

public interface ISecretKeyDao {
	List<SecretKey> getAll();
	SecretKey getById(long id);
	int makePersistence(SecretKey kms);
	int updateStatus(int id, boolean newStatus);
	int delete(int id);
}
