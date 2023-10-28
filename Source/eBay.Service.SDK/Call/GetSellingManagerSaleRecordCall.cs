#region Copyright
//	Copyright (c) 2013 eBay, Inc.
//	
//	This program is licensed under the terms of the eBay Common Development and
//	Distribution License (CDDL) Version 1.0 (the "License") and any subsequent  
//	version thereof released by eBay.  The then-current version of the License can be 
//	found at http://www.opensource.org/licenses/cddl1.php and in the eBaySDKLicense 
//	file that is under the eBay SDK ../docs directory
#endregion

#region Namespaces
using System;
using System.Runtime.InteropServices;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.EPS;
using eBay.Service.Util;

#endregion

namespace eBay.Service.Call
{

	/// <summary>
	/// 
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class GetSellingManagerSaleRecordCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetSellingManagerSaleRecordCall()
		{
			ApiRequest = new GetSellingManagerSaleRecordRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetSellingManagerSaleRecordCall(ApiContext ApiContext)
		{
			ApiRequest = new GetSellingManagerSaleRecordRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves the data for one or more Selling Manager sale records.
		/// 
		/// The standard Trading API deprecation process is not applicable to this call. The user must have a Selling Manager Pro subscription to use this call.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique identifier for the eBay listing associated with the Selling
		/// Manager sale record. Unless the <b>OrderID</b> or <b>OrderLineItemID</b> value is
		/// specified in the request, the <b>ItemID</b> and <b>TransactionID</b> fields must be
		/// used to identify the Selling Manager sale record to retrieve. You can
		/// use <b>GetSellingManagerSoldListings</b> to retrieve the <b>ItemID</b>, <b>TransactionID</b>
		/// or <b>OrderLineItemID</b> values that correspond to the Selling Manager sale
		/// record (<b>SaleRecordID</b>). All four of these fields are returned under the
		/// <b>SellingManagerSoldTransaction</b> container of the
		/// <b>GetSellingManagerSoldListings</b> request.
		/// </param>
		///
		/// <param name="TransactionID">
		/// Unique identifier for the sales transaction associated with the Selling
		/// Manager sale record. Unless the <b>OrderID</b> or
		/// <b>OrderLineItemID</b> value is specified in the request, the
		/// <b>ItemID</b> and <b>TransactionID</b> fields must
		/// be used to identify the Selling Manager sale record to retrieve. You can
		/// use <b>GetSellingManagerSoldListings</b> to retrieve the
		/// <b>ItemID</b>, <b>TransactionID</b> or
		/// <b>OrderLineItemID</b> values that correspond to the Selling
		/// Manager sale record (<b>SaleRecordID</b>). All four of these
		/// fields are returned under the
		/// <b>SellingManagerSoldTransaction</b> container of the
		/// <b>GetSellingManagerSoldListings</b> request.
		/// </param>
		///
		/// <param name="OrderID">
		/// A unique identifier that identifies a single line item or multiple line item order associated with the Selling Manager sale record(s).
		/// 
		/// If an <b>OrderID</b> is used in the request, the <b>OrderLineItemID</b> and
		/// <b>ItemID</b>/<b>TransactionID</b> pair are not required.
		/// 
		/// <span class="tablenote"><b>Note: </b> As of June 2019, eBay has changed the format of order identifier values. The new format is a non-parsable string, globally unique across all eBay marketplaces, and consistent for both single line item and multiple line item orders. Unlike in the past, instead of just being known and exposed to the seller, these unique order identifiers will also be known and used/referenced by the buyer and eBay customer support.
		/// 
		/// For developers and sellers who are already integrated with the Trading API's order management calls, this change shouldn't impact your integration unless you parse the existing order identifiers (e.g., <b>OrderID</b> or <b>OrderLineItemID</b>), or otherwise infer meaning from the format (e.g., differentiating between a single line item order versus a multiple line item order). Because we realize that some integrations may have logic that is dependent upon the old identifier format, eBay is rolling out this Trading API change with version control to support a transition period of approximately 9 months before applications must switch to the new format completely.
		/// 
		/// During the transition period, for developers/sellers using a Trading WSDL older than Version 1113, they can use the <b>X-EBAY-API-COMPATIBILITY-LEVEL</b> HTTP header in API calls to control whether the new or old <b>OrderID</b> format is returned in call response payloads. To get the new <b>OrderID</b> format, the value of the <b>X-EBAY-API-COMPATIBILITY-LEVEL</b> HTTP header must be set to <code>1113</code>. During the transition period and even after, the new and old <b>OrderID</b> formats will still be supported/accepted in all Trading API call request payloads. After the transition period (which will be announced), only the new <b>OrderID</b> format will be returned in all Trading API call response payloads, regardless of the Trading WSDL version used or specified compatibility level.
		/// </span>
		/// 
		/// <span class="tablenote"><b>Note: </b> For sellers integrated with the new order ID format, please note that the identifier for an order will change as it goes from unpaid to paid status. Sellers can check to see if an order has been paid by looking for a value of 'CheckoutComplete' in the <b>OrderStatus.CheckoutStatus</b> field in the response of <b>GetSellingManagerSaleRecord</b> or call. Sellers should  not fulfill orders until buyer has made payment. When using a <b>GetSellingManagerSaleRecord</b> call to retrieve a sale record associated with a specific order, either of these order IDs (paid or unpaid status) can be used to identify the order.
		/// </span>
		/// </param>
		///
		/// <param name="OrderLineItemID">
		/// A unique identifier for an eBay order line item that is associated with
		/// the Selling Manager sale record. This field is created as soon as there
		/// is a commitment to buy (bidder wins the auction, buyer clicks buy button, or buyer purchases item through <b>PlaceOffer</b> call).
		/// 
		/// You can use <b>GetSellingManagerSoldListings</b> to retrieve the <b>ItemID</b>, <b>TransactionID</b> or <b>OrderLineItemID</b> values that correspond to the Selling Manager sale record (<b>SaleRecordID</b>). All four of these fields are returned under the <b>SellingManagerSoldTransaction</b> container of the <b>GetSellingManagerSoldListings</b> request. Unless an <b>OrderID</b> or an <b>ItemID</b>/<b>TransactionID</b> pair is specified in the <b>GetSellingManagerSaleRecord</b> request, the <b>OrderLineItemID</b> field is required.
		/// 
		/// </param>
		///
		public SellingManagerSoldOrderType GetSellingManagerSaleRecord(string ItemID, string TransactionID, string OrderID, string OrderLineItemID)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.OrderID = OrderID;
			this.OrderLineItemID = OrderLineItemID;

			Execute();
			return ApiResponse.SellingManagerSoldOrder;
		}



		#endregion




		#region Properties
		/// <summary>
		/// The base interface object.
		/// </summary>
		/// <remarks>This property is reserved for users who have difficulty querying multiple interfaces.</remarks>
		public ApiCall ApiCallBase
		{
			get { return this; }
		}

		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerSaleRecordRequestType"/> for this API call.
		/// </summary>
		public GetSellingManagerSaleRecordRequestType ApiRequest
		{ 
			get { return (GetSellingManagerSaleRecordRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetSellingManagerSaleRecordResponseType"/> for this API call.
		/// </summary>
		public GetSellingManagerSaleRecordResponseType ApiResponse
		{ 
			get { return (GetSellingManagerSaleRecordResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerSaleRecordRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerSaleRecordRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerSaleRecordRequestType.OrderID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderID
		{ 
			get { return ApiRequest.OrderID; }
			set { ApiRequest.OrderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerSaleRecordRequestType.OrderLineItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderLineItemID
		{ 
			get { return ApiRequest.OrderLineItemID; }
			set { ApiRequest.OrderLineItemID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellingManagerSaleRecordResponseType.SellingManagerSoldOrder"/> of type <see cref="SellingManagerSoldOrderType"/>.
		/// </summary>
		public SellingManagerSoldOrderType SellingManagerSoldOrder
		{ 
			get { return ApiResponse.SellingManagerSoldOrder; }
		}
		

		#endregion

		
	}
}
