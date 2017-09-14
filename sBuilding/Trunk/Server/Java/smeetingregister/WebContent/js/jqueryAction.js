$(document).ready(function() {
	$('#xacnhan').hide();
	$('#list').hide();
	$('#showCombobox').hide();
	$('#deltailBox').prop("disabled", true);
	$('#cothumoi').click(function() {
		$('#xacnhan').hide();
		$('#list').hide();
		$('#normal').show();
		$('#showCombobox').hide();
		$('#deltailBox').show();
		$('#comeOrg').prop("disabled", true);
		$('#hourbegin').prop("disabled", true);
		$('#hourend').prop("disabled", true);
		$('#partaker').prop("disabled", true);
		$('#detail').prop("disabled", true);
		$('#barcode').prop("disabled", false);
		$('#notbarcode').prop("disabled", true);
		$('#deltailBox').prop("disabled", false);
	});
	$('#other').click(function() {
		$('#list').hide();
		$('#xacnhan').show();
		$('#normal').hide();
		$('#showCombobox').show();
		$('#partaker').val("");
		$('#detail').val("");
		$('#hourbegin').val("");
		$('#hourend').val("");
		$('#comeOrg').val("");
		$('#comeOrg').prop("disabled", true);
		$('#hourbegin').prop("disabled", true);
		$('#hourend').prop("disabled", true);
		$('#partaker').prop("disabled", false);
		$('#detail').prop("disabled", false);
		$('#notbarcode').prop("disabled", false);
		$('#barcode').prop("disabled", true);
		$('#deltailBox').prop("disabled", true);
		
	});
//	$('#formadd').submit(function() {
//	    $('#addPartaker').modal('hide');
//	    return false;
//	});
});