using System.Collections.Generic;
using System.Linq;
using KeyPay.DomainModels.V2;
using KeyPay.DomainModels.V2.Employee;
using RestSharp;

namespace KeyPay.ApiFunctions.V2
{
    public class EmployeeDocumentFunction : BaseFunction
    {
        public EmployeeDocumentFunction(ApiRequestExecutor api) : base(api)
        {
        }

        public List<EmployeeDocumentModel> List(int businessId, int employeeId)
        {
            return ApiRequest<List<EmployeeDocumentModel>>($"/business/{businessId}/employee/{employeeId}/document");
        }

        public EmployeeDocumentModel Get(int businessId, int employeeId, int documentId)
        {
            return ApiRequest<EmployeeDocumentModel>(
                $"/business/{businessId}/employee/{employeeId}/document/{documentId}");
        }

        public DocumentFile Content(int businessId, int employeeId, int documentId)
        {
            return ApiByteArrayRequest<DocumentFile>(
                $"/business/{businessId}/employee/{employeeId}/document/{documentId}/content");
        }

        public EmployeeDocumentModel Create(int businessId, int employeeId, FileUploadModel document, bool visible = false)
        {
            var result = ApiFileRequest<List<EmployeeDocumentModel>>(
                $"/business/{businessId}/employee/{employeeId}/document?visible={visible}", document);
            return result.First();
        }

        public List<EmployeeDocumentModel> Create(int businessId, int employeeId, List<FileUploadModel> documents, bool visible = false)
        {
            var result = ApiFileRequest<List<EmployeeDocumentModel>>(
                $"/business/{businessId}/employee/{employeeId}/document?visible={visible}", documents);
            return result;
        }

        public void Delete(int businessId, int employeeId, int id)
        {
            ApiRequest($"/business/{businessId}/employee/{employeeId}/document/{id}", Method.DELETE);
        }

        public EmployeeDocumentModel Put(int businessId, int employeeId, int id, bool visible)
        {
            var result = ApiRequest<EmployeeDocumentModel, dynamic>(
                $"/business/{businessId}/employee/{employeeId}/document", new { id, visible }, Method.PUT);
            return result;
        }
    }
}