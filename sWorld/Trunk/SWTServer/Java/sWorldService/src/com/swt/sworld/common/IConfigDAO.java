package com.swt.sworld.common;

import com.swt.sworld.common.domain.Config;

public interface IConfigDAO {
	Config getValueByName(String name);
	Config getById(int id);
	Config addConfig(Config config);
	Config updateConfig(Config config);
	int deleteConfig(long configId);
}
