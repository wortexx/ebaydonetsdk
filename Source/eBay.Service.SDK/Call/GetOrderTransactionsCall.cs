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
	public class GetOrderTransactionsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetOrderTransactionsCall()
		{
			ApiRequest = new GetOrderTransactionsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetOrderTransactionsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetOrderTransactionsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// The base request type for the <b>GetOrderTransactions</b> call. This call retrieves detailed information about one or more orders or order line items created (or modified) in the last 90 days.
		/// 
		/// Unlike <b>GetOrders</b>, which can be used to retrieve specific orders, or orders created (or modified) within a specific time period, the <b>GetOrderTransactions</b> call only supports the retrieval of specific orders and/or order line items.
		/// </summary>
		/// 
		/// <param name="ItemTransactionIDArrayList">
		/// This container is used if the seller wants to retrieve for one or more order line items. An <b>ItemTransactionID</b> container is required for each order line item that is to be retrieved.  An order line item can be identified with an <b>ItemID</b>/<b>TransactionID</b> pair, with an <b>OrderLineItemID</b> value, or with a <b>SKU</b> value (if a SKU is defined for the order line item).
		/// </param>
		///
		/// <param name="OrderIDArrayList">
		/// This container is used if the seller wants to search for one or more orders. An <b>OrderID</b> field is required for each order that is to be retrieved.  Up to 20 <b>OrderID</b> fields can be used.
		/// 
		/// <span class="tablenote"><b>Note: </b> As of June 2019, eBay has changed the format of order identifier values. The new format is a non-parsable string, globally unique across all eBay marketplaces, and consistent for both single line item and multiple line item orders. Unlike in the past, instead of just being known and exposed to the seller, these unique order identifiers will also be known and used/referenced by the buyer and eBay customer support.
		/// 
		/// For developers and sellers who are already integrated with the Trading API's order management calls, this change shouldn't impact your integration unless you parse the existing order identifiers (e.g., <b>OrderID</b> or <b>OrderLineItemID</b>), or otherwise infer meaning from the format (e.g., differentiating between a single line item order versus a multiple line item order). Because we realize that some integrations may have logic that is dependent upon the old identifier format, eBay is rolling out this Trading API change with version control to support a transition period of approximately 9 months before applications must switch to the new format completely.
		/// 
		/// During the transition period, for developers/sellers using a Trading WSDL older than Version 1113, they can use the <b>X-EBAY-API-COMPATIBILITY-LEVEL</b> HTTP header in API calls to control whether the new or old <b>OrderID</b> format is returned in call response payloads. To get the new <b>OrderID</b> format, the value of the <b>X-EBAY-API-COMPATIBILITY-LEVEL</b> HTTP header must be set to <code>1113</code>. During the transition period and even after, the new and old <b>OrderID</b> formats will still be supported/accepted in all Trading API call request payloads. After the transition period (which will be announced), only the new <b>OrderID</b> format will be returned in all Trading API call response payloads, regardless of the Trading WSDL version used or specified compatibility level.
		/// </span>
		/// 
		/// <span class="tablenote"><b>Note: </b> For sellers integrated with the new order ID format, please note that the identifier for an order will change as it goes from unpaid to paid status. Sellers can check to see if an order has been paid by looking for a value of 'Complete' in the <b>CheckoutStatus.Status</b> field in the response of <b>GetOrders</b> or <b>GetOrderTransactions</b> call, or in the <b>Status.CompleteStatus</b> field in the response of <b>GetItemTransactions</b> or <b>GetSellerTransactions</b> call. Sellers should  not fulfill orders until buyer has made payment. When using a <b>GetOrders</b> or <b>GetOrderTransactions</b> call to retrieve specific order(s), either of these order IDs (paid or unpaid status) can be used to retrieve an order.
		/// </span>
		/// </param>
		///
		/// <param name="Platform">
		/// <span class="tablenote"><b>Note: </b> This field should no longer be used since its sole purpose was to allow the seller to filter between eBay orders and Half.com orders, and the Half.com site no longer exists.
		/// </span>
		/// </param>
		///
		/// <param name="IncludeFinalValueFees">
		/// This field is included and set to <code>true</code> if the user wants to view the Final Value Fee (FVF) for all order line items in the response. The Final Value Fee is returned in the <b>Transaction.FinalValueFee</b> field. The Final Value Fee is assessed right after the creation of an order line item.
		/// <br/>
		/// </param>
		///
		public OrderTypeCollection GetOrderTransactions(ItemTransactionIDTypeCollection ItemTransactionIDArrayList, StringCollection OrderIDArrayList, TransactionPlatformCodeType Platform, bool IncludeFinalValueFees)
		{
			this.ItemTransactionIDArrayList = ItemTransactionIDArrayList;
			this.OrderIDArrayList = OrderIDArrayList;
			this.Platform = Platform;
			this.IncludeFinalValueFees = IncludeFinalValueFees;

			Execute();
			return ApiResponse.OrderArray;
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
		/// Gets or sets the <see cref="GetOrderTransactionsRequestType"/> for this API call.
		/// </summary>
		public GetOrderTransactionsRequestType ApiRequest
		{ 
			get { return (GetOrderTransactionsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetOrderTransactionsResponseType"/> for this API call.
		/// </summary>
		public GetOrderTransactionsResponseType ApiResponse
		{ 
			get { return (GetOrderTransactionsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrderTransactionsRequestType.ItemTransactionIDArray"/> of type <see cref="ItemTransactionIDTypeCollection"/>.
		/// </summary>
		public ItemTransactionIDTypeCollection ItemTransactionIDArrayList
		{ 
			get { return ApiRequest.ItemTransactionIDArray; }
			set { ApiRequest.ItemTransactionIDArray = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrderTransactionsRequestType.OrderIDArray"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection OrderIDArrayList
		{ 
			get { return ApiRequest.OrderIDArray; }
			set { ApiRequest.OrderIDArray = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrderTransactionsRequestType.Platform"/> of type <see cref="TransactionPlatformCodeType"/>.
		/// </summary>
		public TransactionPlatformCodeType Platform
		{ 
			get { return ApiRequest.Platform; }
			set { ApiRequest.Platform = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrderTransactionsRequestType.IncludeFinalValueFees"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeFinalValueFees
		{ 
			get { return ApiRequest.IncludeFinalValueFees; }
			set { ApiRequest.IncludeFinalValueFees = value; }
		}
				/// <summary>
		/// Retrieves information about one or more orders or one or more transactions
		/// (or both), thus displacing the need to call GetOrders and GetItemTransactions
		/// separately.
		/// </summary>
		/// 
		/// <param name="ItemTransactionIDArrayList">
		/// An array of ItemTransactionIDs.
		/// </param>
		///
		public OrderTypeCollection GetOrderTransactions(ItemTransactionIDTypeCollection ItemTransactionIDArrayList)
		{
			this.ItemTransactionIDArrayList = ItemTransactionIDArrayList;
			this.OrderIDArrayList = null;

			Execute();
			return ApiResponse.OrderArray;
		}
		/// <summary>
		/// Retrieves information about one or more orders or one or more transactions
		/// (or both), thus displacing the need to call GetOrders and GetItemTransactions
		/// separately.
		/// </summary>
		/// 
		/// <param name="OrderIDArrayList">
		/// An array of OrderIDs.
		/// </param>
		///
		public OrderTypeCollection GetOrderTransactions(StringCollection OrderIDArrayList)
		{
			this.ItemTransactionIDArrayList = null;
			this.OrderIDArrayList = OrderIDArrayList;

			Execute();
			return ApiResponse.OrderArray;
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetOrderTransactionsResponseType.OrderArray"/> of type <see cref="OrderTypeCollection"/>.
		/// </summary>
		public OrderTypeCollection OrderList
		{ 
			get { return ApiResponse.OrderArray; }
		}
		

		#endregion

		
	}
}
