//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using ProAbonoApi.Tools;

namespace ProAbonoApi.Implementation
{
    /// <summary>
    /// ProAbono client for API
    /// </summary>
    partial class ClientApiV1
    {
        #region Single customer

        /// <summary>
        /// Get a customer from its reference
        /// </summary>
        /// <param name="customer">Found customer, if succeeded</param>
        /// <param name="referenceCustomer">(optional) reference of requested customer, required if idCustomer is null</param>
        /// <param name="referenceOffer">(optional) if provided, adds a customer-specific 'subscribe' links, allowing the customer to subscribe to given offer</param>
        public virtual RequestReport GetCustomer(out Customer customer, object referenceCustomer, object referenceOffer)
        {
            customer = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Customer);
            // if succeeded
            if(result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer))
                    .AddUrlParameter(EndpointParametersV1.ReferenceOffer, this.ToString(referenceOffer));

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out customer, response);
            }
            return result;
        }
        /// <summary>
        /// Insert or update a customer
        /// </summary>
        /// <param name="customer">Inserted/updated customer</param>
        /// <param name="referenceSegment">(optional) the segment you want the push the customer into, if not provided and you have multiple segments, defaults on the first segment</param>
        /// <param name="referenceCustomer">(optional) new or existing customer reference</param>
        /// <param name="name">(optional) customer name</param>
        /// <param name="email">(optional) customer email</param>
        /// <param name="language">(optional) customer language, fallback on default</param>
        /// <param name="referenceAffiliation">(optional) affiliation key</param>
        /// <param name="referenceOffer">(optional) if provided, adds a customer-specific 'subscribe' links, allowing the customer to subscribe to given offer</param>
        public virtual RequestReport SaveCustomer(out Customer customer, object referenceSegment, object referenceCustomer, string name, string email, string language, object referenceAffiliation, object referenceOffer, long? idOffer)
        {
            customer = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Customer);
            // if succeeded
            if(result.IsSuccess())
            {
                // append optional parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceOffer, this.ToString(referenceOffer))
                    .AddUrlParameter(EndpointParametersV1.IdOffer, idOffer);

                // build the customer to send
                var customerToSend = new Customer
                                     {
                                       ReferenceCustomer = this.ToString(referenceCustomer),
                                       ReferenceSegment = this.ToString(referenceSegment),
                                       Name = name,
                                       Email = email,
                                       Language = language,
                                       ReferenceAffiliation = this.ToString(referenceAffiliation)
                                     };

                // send the request
                var response = this.Send(request, customerToSend);

                // handle the response
                result = this.HandleResponse(out customer, response);
            }
            return result;
        }

        #endregion

        #region Multiple customers

        /// <summary>
        /// List all customers
        /// </summary>
        /// <param name="customers">the customers paginated list</param>
        /// <param name="referenceSegment">(optional) the related segment, if not provided and you have multiple segments, defaults on the first segment</param>
        /// <param name="referenceFeature">(optional) if provided, get only customers having access to given feature. Adds the current usage in the returned object</param>
        /// <param name="page">(optional) Pagination : page index (starts from 1) </param>
        /// <param name="sizePage">(optional) Pagination : page size (default is 10) </param>
        public virtual RequestReport ListCustomers(out ListPaginated<Customer> customers, object referenceSegment, object referenceFeature, int? page, int? sizePage)
        {
            customers = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Customers);
            // if succeeded
            if(result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceSegment, this.ToString(referenceSegment))
                    .AddUrlParameter(EndpointParametersV1.PrefixReferenceOffer, this.ToString(referenceFeature))
                    .AddUrlParameter(EndpointParametersV1.ReferenceFeature, this.ToString(referenceFeature))
                    .AddUrlParameter(EndpointParametersV1.Page, page)
                    .AddUrlParameter(EndpointParametersV1.SizePage, sizePage);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out customers, response);
            }
            return result;
        }

        #endregion
        
        #region Customer address - billing

        /// <summary>
        /// Get a customer billing address
        /// </summary>
        /// <param name="address">Found address, if succeeded</param>
        /// <param name="referenceCustomer">(mandatory) required customer reference</param>
        public virtual RequestReport GetCustomerBillingAddress(out Address address, object referenceCustomer)
        {
            address = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.CustomerAddressBilling);
            // if succeeded
            if(result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer));

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out address, response);
            }
            return result;
        }
        /// <summary>
        /// Insert or update customer billing address
        /// </summary>
        /// <param name="address">Inserted/updated address</param>
        /// <param name="referenceCustomer">(mandatory) the customer reference</param>
        /// <param name="company">(optional) customer company</param>
        /// <param name="firstname">(optional) customer first name</param>
        /// <param name="lastname">(optional) customer last name</param>
        /// <param name="line1">(optional) address : line 1</param>
        /// <param name="line2">(optional) address : line 2</param>
        /// <param name="zipCode">(optional) address : zip code</param>
        /// <param name="city">(optional) address : city</param>
        /// <param name="country">(optional) address : country</param>
        /// <param name="region">(optional) address : region of the country</param>
        /// <param name="taxInformation">(optional) company : tax information</param>
        /// <param name="phone">(optional) customer : phone number</param>
        public virtual RequestReport SaveCustomerBillingAddress(out Address address, object referenceCustomer, string company, string firstname, string lastname, string line1, string line2, string zipCode, string city, string country, string region, string taxInformation, string phone)
        {
            address = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.CustomerAddressBilling);
            // if succeeded
            if(result.IsSuccess())
            {
                // build the address to send
                var addressToSend = new Address
                                     {
                                       ReferenceCustomer = referenceCustomer.ToString(),
                                       Company = company,
                                       FirstName = firstname,
                                       LastName = lastname,
                                       AddressLine1 = line1,
                                       AddressLine2 = line2,
                                       ZipCode = zipCode,
                                       City = city,
                                       Country = country,
                                       Region = region,
                                       TaxInformation = taxInformation,
                                       Phone = phone
                                     };

                // send the request
                var response = this.Send(request, addressToSend);

                // handle the response
                result = this.HandleResponse(out address, response);
            }
            return result;
        }

        #endregion

        #region Customer address - shipping

        /// <summary>
        /// Get a customer billing address
        /// </summary>
        /// <param name="address">Found address, if succeeded</param>
        /// <param name="referenceCustomer">(mandatory) required customer reference</param>
        public virtual RequestReport GetCustomerShippingAddress(out Address address, object referenceCustomer)
        {
            address = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.CustomerAddressShipping);
            // if succeeded
            if(result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer));

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out address, response);
            }
            return result;
        }
        /// <summary>
        /// Insert or update customer billing address
        /// </summary>
        /// <param name="address">Inserted/updated address</param>
        /// <param name="referenceCustomer">(mandatory) the customer reference</param>
        /// <param name="company">(optional) customer company</param>
        /// <param name="firstname">(optional) customer first name</param>
        /// <param name="lastname">(optional) customer last name</param>
        /// <param name="line1">(optional) address : line 1</param>
        /// <param name="line2">(optional) address : line 2</param>
        /// <param name="zipCode">(optional) address : zip code</param>
        /// <param name="city">(optional) address : city</param>
        /// <param name="country">(optional) address : country</param>
        /// <param name="region">(optional) address : region of the country</param>
        /// <param name="taxInformation">(optional) company : tax information</param>
        /// <param name="phone">(optional) customer : phone number</param>
        public virtual RequestReport SaveCustomerShippingAddress(out Address address, object referenceCustomer, string company, string firstname, string lastname, string line1, string line2, string zipCode, string city, string country, string region, string taxInformation, string phone)
        {
            address = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.CustomerAddressShipping);
            // if succeeded
            if(result.IsSuccess())
            {
                // build the address to send
                var addressToSend = new Address
                                     {
                                       Company = company,
                                       FirstName = firstname,
                                       LastName = lastname,
                                       AddressLine1 = line1,
                                       AddressLine2 = line2,
                                       ZipCode = zipCode,
                                       City = city,
                                       Country = country,
                                       Region = region,
                                       TaxInformation = taxInformation,
                                       Phone = phone
                                     };

                // send the request
                var response = this.Send(request, addressToSend);

                // handle the response
                result = this.HandleResponse(out address, response);
            }
            return result;
        }

        #endregion

        #region Customer settings - payment

        /// <summary>
        /// Get a customer billing address
        /// </summary>
        /// <param name="settings">Found settings, if succeeded</param>
        /// <param name="referenceCustomer">(mandatory) required customer reference</param>
        public virtual RequestReport GetCustomerPaymentSettings(out SettingsPayment settings, object referenceCustomer)
        {
            settings = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.CustomerSettingsPayment);
            // if succeeded
            if(result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer));

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out settings, response);
            }
            return result;
        }
        /// <summary>
        /// Insert or update customer billing address
        /// </summary>
        /// <param name="settings">Inserted/updated settings</param>
        /// <param name="referenceCustomer">(mandatory) the customer reference</param>
        /// <param name="typePayment">(optional) the payment type</param>
        /// <param name="dateNextBilling">(optional) next billing date. If null, the customer won't be billed until the next time he subscribes.</param>
        public virtual RequestReport SaveCustomerPaymentSettings(out SettingsPayment settings, object referenceCustomer, TypePayment typePayment, DateTime? dateNextBilling)
        {
            settings = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.CustomerSettingsPayment);
            // if succeeded
            if(result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer));

                // build the address to send
                var addressToSend = new SettingsPayment
                                     {
                                       TypePayment = typePayment,
                                       DateNextBilling = dateNextBilling
                                     };

                // send the request
                var response = this.Send(request, addressToSend);

                // handle the response
                result = this.HandleResponse(out settings, response);
            }
            return result;
        }

        #endregion
    }
}