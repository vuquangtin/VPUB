package com.sworld.web.services;

import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.Request;
import javax.ws.rs.core.UriInfo;

import com.sworld.common.Defines;


@Path(Defines.CONFIG)
@Produces(Defines.APPLICATION_JSON)
public class Configuration {
	@Context
	UriInfo uriInfo;

	@Context
	Request request;
	

}