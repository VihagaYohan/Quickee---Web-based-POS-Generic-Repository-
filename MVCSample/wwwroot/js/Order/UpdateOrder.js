var productDropDown = document.getElementsByClassName('orderItem-ProductId');
var row
var cell

// object array
var obj_Order = new Object();


// calculate order line total
function calculateLineTotal(x) {
	cell = x.cellIndex

	console.log('cell index : ' + cell)


	row = x.parentElement.rowIndex
	row = row - 1; // target table row

	console.log('row index : ' + row)

	var table = document.getElementById('table-OrderItems')

	var quantity = table.children[row].children[3].children[0].value // line product quantity
	console.log('Quantity :' + quantity);

	var unitPrice = table.children[row].children[4].children[0].innerHTML // line product unit price
	console.log('Unit price : ' + unitPrice)

	var lineTotal = quantity * unitPrice;
	console.log(lineTotal)

	table.children[row].children[5].textContent = lineTotal // order line item total

	getTotalAmount();
}

// calculate total order amount
function getTotalAmount() {
	var totalAmount = 0;
	var subTotal;
	var rowCollection;

	rowCollection = Array.from(document.getElementsByClassName('table-Row')) // array of order item table rows

	for (var i = 0; i < rowCollection.length; i++) {
		//subTotal = Number(rowCollection[i].children[4].innerHTML)
		subTotal = parseFloat(rowCollection[i].children[5].textContent)
		console.log(subTotal)
		totalAmount = totalAmount + subTotal;
	}

	document.getElementById('grandTotal').textContent = totalAmount;
}

// pass order object
var btnUpdate = document.getElementById('btnUpdate');
btnUpdate.onclick = updateOrder;

// update order
function updateOrder(e) {
	e.preventDefault();

	// order id
	var orderId = document.getElementById('orderId').textContent;

	// customer id and customer name
	var customer = document.getElementById('customerId');

	var customerId = customer.options[customer.selectedIndex].value
	var customerName = customer.value;

	// get order items
	var tableRow = Array.from(document.getElementsByClassName('table-Row'))
	var arr_OrderItems = []; // array of order items

	/*var obj_OrderItems = new Object();*/ // order item object

	for (var i = 0; i < tableRow.length; i++) {
		var obj_OrderItems = {
			orderItemId: tableRow[i].children[0].children[0].value, // order item id
			productId: tableRow[i].children[1].innerText, // product id
			productName: tableRow[i].children[2].innerText, // product name
			quantity: tableRow[i].children[3].children[0].value, // quantity
			unitPrice: tableRow[i].children[4].innerText, // product unit price
			lineTotal: tableRow[i].children[5].textContent // line total
		}

		arr_OrderItems.push(obj_OrderItems) // add to order items object array
	}

	obj_Order.orderId = orderId;
	obj_Order.customerId = customerId;
	//obj_Order.customer = customer;
	obj_Order.orderItems = arr_OrderItems;
	obj_Order.totalAmount = document.getElementById('grandTotal').textContent;

	console.log(obj_Order);

	$.ajax({
		url: '/Order/Edit',
		type: 'POST',
		dataType: "json",
		data: obj_Order,
		success: function (response) {
			$("#dvtest").html(response);
		}
	});

}

//var btnRemove = document.querySelector('#remove')
var btnRemove = document.querySelectorAll('.remove')
btnRemove.onclick = hello;

// sample method
function hello(e) {
	e.preventDefault();

	var arr_TableRows = document.getElementsByClassName('table-Row')
	console.log(arr_TableRows[0].children[0])
}