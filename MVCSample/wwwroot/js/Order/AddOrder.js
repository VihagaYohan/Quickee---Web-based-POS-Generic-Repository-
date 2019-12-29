var products = document.getElementById('productId') // products dropdown
var arr = Array.from(products); // array of products

var rowCollection = document.getElementsByClassName('table-Row');

var lineTotal;
var subTotal;

// create order item object array
var arr_OrderItems = [];

// create order object
var obj_Order = new Object();

// sample method
function helloWorld(event) {
	event.preventDefault()
	alert('Hello World');
}

products.addEventListener('change', function () {

	// unit price
	var unitPrice = arr[products.selectedIndex].dataset.unitPrice;
	document.getElementById('unitPrice').value = unitPrice

	// quantity
	var numProductCount = document.getElementById('quantity').value;

	// show line total
	lineTotal = numProductCount * unitPrice;

	// table row collection
	var rowCollection = document.getElementsByClassName('table-Row');

})

var buttonIndex = 0;

function addRows(event) {
	event.preventDefault()

	var table = document.getElementById("table-OrderItems");

	// Create a <tr> element and add it to the 1st position of the table:
	var row = table.insertRow(0);

	row.className = 'table-Row';

	// Insert new cells (<td> elements) at the 1st and 2nd position of the "new" <tr> element:
	var productName = row.insertCell(0);
	var quantity = row.insertCell(1);
	var unitPrice = row.insertCell(2);
	var lineTotal = row.insertCell(3);

	// Add some text to the new cells:
	var productId = arr[products.selectedIndex].value;
	productName.innerHTML = arr[products.selectedIndex].innerHTML;
	quantity.innerHTML = document.getElementById('quantity').value;
	unitPrice.innerHTML = document.getElementById('unitPrice').value;
	lineTotal.innerHTML = document.getElementById('quantity').value * document.getElementById('unitPrice').value;

	var col = document.createElement('td');

	var btnDelete = document.createElement('button');
	btnDelete.className = 'btn-Delete btn btn-warning';
	btnDelete.innerText = 'Remove'
	btnDelete.id = buttonIndex;
	buttonIndex = buttonIndex + 1;

	col.appendChild(btnDelete)
	row.appendChild(col)

	getTotalOrderAmount()

	// order item object
	var obj_OrderItem =
	{
		productId: productId,
		productName: productName.innerText,
		quantity: quantity.innerText,
		unitPrice: unitPrice.innerText,
		lineTotal: quantity.innerText * unitPrice.innerText
	};

	// adding order item object to array
	arr_OrderItems.push(obj_OrderItem);

	//btnDelete.onclick = getRowIndex
	btnDelete.onclick = deleteOrderLine
}

// button click event for add button
var btnAdd = document.getElementById('btnAdd');
btnAdd.onclick = addRows
//btnAdd.onclick = validation

// sample method to get total order amount
function getTotalOrderAmount() {
	var orderTotal = 0;
	var rowCollection = document.getElementsByClassName('table-Row');

	for (var i = 0; i < rowCollection.length; i++) {
		var subTotal = Number(rowCollection[i].children[3].innerHTML);
		orderTotal = orderTotal + subTotal
	}

	// set order total amount
	document.getElementById('grandTotal').innerText = orderTotal;

	// set styling for grand total row
	document.getElementById('row_grandTotal').style.fontWeight = "bold";
}

// button click event for save button
var btnSave = document.getElementById('btnSave');
btnSave.onclick = passObject

function passObject(event) {
	event.preventDefault()

	// get cutomer id and customer name
	var customer = document.getElementById('customerId')
	var customerId = customer.options[customer.selectedIndex].value

	// add values to order object
	obj_Order.customerId = customerId;
	obj_Order.orderDate = new Date().toLocaleDateString();
	obj_Order.orderItems = arr_OrderItems;

	// get total order amount
	var orderAmount = 0;
	for (var i = 0; i < arr_OrderItems.length; i++) {
		var amount = arr_OrderItems[i].lineTotal;
		orderAmount = orderAmount + amount
	}

	// set total order amount to order object
	obj_Order.totalAmount = orderAmount;

	console.log('--Order object--');
	console.log(orderAmount);

	$.ajax({
		type: 'POST',
		data: obj_Order, // #2
		url: '/Order/Add',
		//contentType: 'application/json', #3
		//dataType: 'json', #2
		//success: alert('Youhou'),
		//error: alert('not good')
	});
}

// delete order lines
function deleteOrderLine(e) {
	e.preventDefault()
	var buttonId;

	e = e.target || e.srcElement;
	if (e.nodeName === 'BUTTON') {
		buttonId = e.id;

		var table_OrderItems = document.getElementById('table-OrderItems');
		var table_Row = document.getElementById(buttonId).parentElement.parentElement;

		table_OrderItems.deleteRow(table_Row);

		getTotalOrderAmount();
	}

}

function validation(e) {
	e.preventDefault();

	//var btnStatus = false;
	//var customer = document.getElementById('customerId').value;
	//var product = document.getElementById('productId').value;

	//if (customer == "Select a customer") {
	//	alert('Please select a customer')
	//}
	//if (product == "Select a product") {
	//	alert('Please select a product')
	//}


	bootstrap_alert = function () { }
	bootstrap_alert.warning = function (message) {
		$('#alert_placeholder').html('<div class="alert"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')
	}


	$('#clickme').on('click', function () {
		bootstrap_alert.warning('Your text goes here');
	});

	//btnSave.disabled = true
}


