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
	public class ReviseSellingManagerSaleRecordCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ReviseSellingManagerSaleRecordCall()
		{
			ApiRequest = new ReviseSellingManagerSaleRecordRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public ReviseSellingManagerSaleRecordCall(ApiContext ApiContext)
		{
			ApiRequest = new ReviseSellingManagerSaleRecordRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Request type containing the input fields for the <b>ReviseSellingManagerSaleRecord</b>
		/// call. The standard Trading API deprecation process is not applicable to this
		/// call. The user must have a Selling Manager Pro subscription to use this call.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique identifier for an eBay listing. A listing can have multiple
		/// order line items, but only one <b>ItemID</b> value. An <b>ItemID</b> can be
		/// paired up with a corresponding <b>TransactionID</b> and used as an input filter
		/// for <b>ReviseSellingManagerSaleRecord</b>. The <b>ItemID</b>/<b>TransactionID</b> pair
		/// corresponds to a Selling Manager <b>SaleRecordID</b>, which can be retrieved
		/// with the <b>GetSellingManagerSaleRecord</b> call.
		/// 
		/// Unless an <b>OrderLineItemID</b> is used to identify an order line item,
		/// or the <b>OrderID</b> is used to identify an order, the <b>ItemID</b>/<b>TransactionID</b> pair must be
		/// specified. If <b>OrderID</b> or <b>OrderLineItemID</b> are specified, the
		/// <b>ItemID</b>/<b>TransactionID</b> pair is ignored if present in the same request.
		/// </param>
		///
		/// <param name="TransactionID">
		/// Unique identifier for an eBay sales transaction. This identifier is created once there is a commitment to buy (bidder wins the auction, buyer clicks buy button, or buyer purchases item through <b>PlaceOffer</b> call). Since an auction listing can only have one sales transaction during the duration of the listing, the <b>TransactionID</b> value for auction listings is always <code>0</code>.
		/// 
		/// The <b>ItemID</b>/<b>TransactionID</b> pair can be
		/// used to identify an order line item in a  <b>ReviseSellingManagerSaleRecord</b> call. The
		/// <b>ItemID</b>/<b>TransactionID</b> pair corresponds to a Selling Manager <b>SaleRecordID</b>,
		/// which can be retrieved with the <b>GetSellingManagerSaleRecord</b> call.
		/// 
		/// Unless an <b>OrderLineItemID</b> is used to identify an order line item,
		/// or the <b>OrderID</b> is used to identify an order, the <b>ItemID</b>/<b>TransactionID</b> pair must be
		/// specified. If <b>OrderID</b> or <b>OrderLineItemID</b> are specified, the
		/// <b>ItemID</b>/<b>TransactionID</b> pair is ignored if present in the same request.
		/// </param>
		///
		/// <param name="OrderID">
		/// A unique identifier that identifies a single line item or multiple line item order associated with the Selling Manager sale record(s).
		/// 
		/// If an <b>OrderID</b> is used in the request, the <b>OrderLineItemID</b> and
		/// <b>ItemID</b>/<b>TransactionID</b> pair are ignored if they are specified in the same request.
		/// 
		/// <span class="tablenote"><b>Note: </b> As of June 2019, eBay has changed the format of order identifier values. The new format is a non-parsable string, globally unique across all eBay marketplaces, and consistent for both single line item and multiple line item orders. Unlike in the past, instead of just being known and exposed to the seller, these unique order identifiers will also be known and used/referenced by the buyer and eBay customer support.
		/// 
		/// For developers and sellers who are already integrated with the Trading API's order management calls, this change shouldn't impact your integration unless you parse the existing order identifiers (e.g., <b>OrderID</b> or <b>OrderLineItemID</b>), or otherwise infer meaning from the format (e.g., differentiating between a single line item order versus a multiple line item order). Because we realize that some integrations may have logic that is dependent upon the old identifier format, eBay is rolling out this Trading API change with version control to support a transition period of approximately 9 months before applications must switch to the new format completely.
		/// 
		/// During the transition period, for developers/sellers using a Trading WSDL older than Version 1113, they can use the <b>X-EBAY-API-COMPATIBILITY-LEVEL</b> HTTP header in API calls to control whether the new or old <b>OrderID</b> format is returned in call response payloads. To get the new <b>OrderID</b> format, the value of the <b>X-EBAY-API-COMPATIBILITY-LEVEL</b> HTTP header must be set to <code>1113</code>. During the transition period and even after, the new and old <b>OrderID</b> formats will still be supported/accepted in all Trading API call request payloads. After the transition period (which will be announced), only the new <b>OrderID</b> format will be returned in all Trading API call response payloads, regardless of the Trading WSDL version used or specified compatibility level.
		/// </span>
		/// 
		/// <span class="tablenote"><b>Note: </b> For sellers integrated with the new order ID format, please note that the identifier for an order will change as it goes from unpaid to paid status. When using a <b>ReviseSellingManagerSaleRecord</b> call, either of these order IDs (paid or unpaid status) can be used to update a Sale Record.
		/// </span>
		/// </param>
		///
		/// <param name="SellingManagerSoldOrder">
		/// Container consisting of order costs, shipping details, order status, and
		/// other information. The changes made under this container will update the
		/// order in Selling Manager.
		/// </param>
		///
		/// <param name="OrderLineItemID">
		/// A unique identifier for an eBay order line item. This identifier is created once there is a commitment to buy (bidder wins the auction, buyer clicks buy button, or buyer purchases item through <b>PlaceOffer</b> call).
		/// 
		/// Unless an <b>ItemID</b>/<b>TransactionID</b> pair is used to identify an order line item, or the <b>OrderID</b> is used to identify an order, the <b>OrderLineItemID</b> must be specified. For a multiple line item order, <b>OrderID</b> should be used. If <b>OrderLineItemID</b> is specified, the <b>ItemID</b>/<b>TransactionID</b> pair are ignored if present in the same request.
		/// </param>
		///
		public void ReviseSellingManagerSaleRecord(string ItemID, string TransactionID, string OrderID, SellingManagerSoldOrderType SellingManagerSoldOrder, string OrderLineItemID)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.OrderID = OrderID;
			this.SellingManagerSoldOrder = SellingManagerSoldOrder;
			this.OrderLineItemID = OrderLineItemID;

			Execute();
			
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
		/// Gets or sets the <see cref="ReviseSellingManagerSaleRecordRequestType"/> for this API call.
		/// </summary>
		public ReviseSellingManagerSaleRecordRequestType ApiRequest
		{ 
			get { return (ReviseSellingManagerSaleRecordRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="ReviseSellingManagerSaleRecordResponseType"/> for this API call.
		/// </summary>
		public ReviseSellingManagerSaleRecordResponseType ApiResponse
		{ 
			get { return (ReviseSellingManagerSaleRecordResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseSellingManagerSaleRecordRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseSellingManagerSaleRecordRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseSellingManagerSaleRecordRequestType.OrderID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderID
		{ 
			get { return ApiRequest.OrderID; }
			set { ApiRequest.OrderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseSellingManagerSaleRecordRequestType.SellingManagerSoldOrder"/> of type <see cref="SellingManagerSoldOrderType"/>.
		/// </summary>
		public SellingManagerSoldOrderType SellingManagerSoldOrder
		{ 
			get { return ApiRequest.SellingManagerSoldOrder; }
			set { ApiRequest.SellingManagerSoldOrder = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseSellingManagerSaleRecordRequestType.OrderLineItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderLineItemID
		{ 
			get { return ApiRequest.OrderLineItemID; }
			set { ApiRequest.OrderLineItemID = value; }
		}
		
		

		#endregion

		
	}
}
