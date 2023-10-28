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
	public class GetSellingManagerEmailLogCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetSellingManagerEmailLogCall()
		{
			ApiRequest = new GetSellingManagerEmailLogRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetSellingManagerEmailLogCall(ApiContext ApiContext)
		{
			ApiRequest = new GetSellingManagerEmailLogRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves a log of emails sent, or scheduled to be sent, to buyers.
		/// 
		/// The standard Trading API
		/// deprecation process is not applicable to this call.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique identifier for the eBay listing associated with the Selling
		/// Manager email log. Unless the <b>OrderID</b> or <b>OrderLineItemID</b> value is
		/// specified in the request, the <b>ItemID</b> and <b>TransactionID</b> fields must be
		/// used to identify the Selling Manager email log to retrieve. You can
		/// use <b>GetSellingManagerSoldListings</b> to retrieve the <b>ItemID</b>, <b>TransactionID</b>
		/// or <b>OrderLineItemID</b> values that correspond to the Selling Manager sale
		/// record (<b>SaleRecordID</b>). All four of these fields are returned under the
		/// <b>SellingManagerSoldTransaction</b> container of the
		/// <b>GetSellingManagerSoldListings</b> request.
		/// </param>
		///
		/// <param name="TransactionID">
		/// Unique identifier for the sales transaction associated with
		/// the Selling Manager email log. Unless the <b>OrderID</b> or <b>OrderLineItemID</b>
		/// value is specified in the request, the <b>ItemID</b> and <b>TransactionID</b> fields
		/// must be used to identify the Selling Manager email log to retrieve.
		/// You can use <b>GetSellingManagerSoldListings</b> to retrieve the <b>ItemID</b>,
		/// <b>TransactionID</b> or <b>OrderLineItemID</b> values that correspond to the Selling
		/// Manager sale record (<b>SaleRecordID</b>). All four of these fields are
		/// returned under the <b>SellingManagerSoldTransaction</b> container of the
		/// <b>GetSellingManagerSoldListings</b> request.
		/// </param>
		///
		/// <param name="OrderID">
		/// A unique identifier that identifies a single line item or multiple line item order associated with the Selling Manager email log.
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
		/// <span class="tablenote"><b>Note: </b> For sellers integrated with the new order ID format, please note that the identifier for an order will change as it goes from unpaid to paid status. Sellers can check to see if an order has been paid by looking for a value of 'Complete' in the <b>CheckoutStatus.Status</b> field in the response of <b>GetOrders</b> or <b>GetOrderTransactions</b> call, or in the <b>Status.CompleteStatus</b> field in the response of <b>GetItemTransactions</b> or <b>GetSellerTransactions</b> call. When using a <b>GetSellingManagerEmailLog</b> call, either of these order IDs (paid or unpaid status) can be used to identify the order. Similarly, either of these order IDs (paid or unpaid status) can be used in <b>GetOrders</b> or <b>GetOrderTransactions</b> call to retrieve specific order(s).
		/// </span>
		/// </param>
		///
		/// <param name="EmailDateRange">
		/// Specifies the earliest (oldest) and latest (most recent) dates to use in a
		/// date range filter based on email sent date. Each of the time ranges can be
		/// up to 90 days.
		/// </param>
		///
		/// <param name="OrderLineItemID">
		/// A unique identifier for an eBay order line item that is associated with
		/// the Selling Manager email log. This field is created as soon as there
		/// is a commitment to buy (bidder wins the auction, buyer clicks buy button, or buyer purchases item through <b>PlaceOffer</b> call).
		/// 
		/// You can use <b>GetSellingManagerSoldListings</b> to retrieve the <b>ItemID</b>, <b>TransactionID</b> or <b>OrderLineItemID</b> values that correspond to the Selling Manager sale record (<b>SaleRecordID</b>). All four of these fields are returned under the <b>SellingManagerSoldTransaction</b> container of the <b>GetSellingManagerSoldListings</b> request. Unless an <b>OrderID</b> or an <b>ItemID</b>/<b>TransactionID</b> pair is specified in the <b>GetSellingManagerSaleRecord</b> request, the <b>OrderLineItemID</b> field is required.
		/// 
		/// </param>
		///
		public SellingManagerEmailLogTypeCollection GetSellingManagerEmailLog(string ItemID, long TransactionID, string OrderID, TimeRangeType EmailDateRange, string OrderLineItemID)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.OrderID = OrderID;
			this.EmailDateRange = EmailDateRange;
			this.OrderLineItemID = OrderLineItemID;

			Execute();
			return ApiResponse.EmailLog;
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
		/// Gets or sets the <see cref="GetSellingManagerEmailLogRequestType"/> for this API call.
		/// </summary>
		public GetSellingManagerEmailLogRequestType ApiRequest
		{ 
			get { return (GetSellingManagerEmailLogRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetSellingManagerEmailLogResponseType"/> for this API call.
		/// </summary>
		public GetSellingManagerEmailLogResponseType ApiResponse
		{ 
			get { return (GetSellingManagerEmailLogResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerEmailLogRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerEmailLogRequestType.TransactionID"/> of type <see cref="long"/>.
		/// </summary>
		public long TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerEmailLogRequestType.OrderID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderID
		{ 
			get { return ApiRequest.OrderID; }
			set { ApiRequest.OrderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerEmailLogRequestType.EmailDateRange"/> of type <see cref="TimeRangeType"/>.
		/// </summary>
		public TimeRangeType EmailDateRange
		{ 
			get { return ApiRequest.EmailDateRange; }
			set { ApiRequest.EmailDateRange = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerEmailLogRequestType.OrderLineItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderLineItemID
		{ 
			get { return ApiRequest.OrderLineItemID; }
			set { ApiRequest.OrderLineItemID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellingManagerEmailLogResponseType.EmailLog"/> of type <see cref="SellingManagerEmailLogTypeCollection"/>.
		/// </summary>
		public SellingManagerEmailLogTypeCollection EmailLogList
		{ 
			get { return ApiResponse.EmailLog; }
		}
		

		#endregion

		
	}
}
