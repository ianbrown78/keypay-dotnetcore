using System.Collections.Generic;
using System.Linq;
using KeyPay.DomainModels.V2;
using KeyPay.DomainModels.V2.Business;
using RestSharp;

namespace KeyPay.ApiFunctions.V2
{
    public class DocumentFunction : BaseFunction
    {
        public DocumentFunction(ApiRequestExecutor api) : base(api)
        {
        }

        public List<DocumentModel> List(int businessId)
        {
            return ApiRequest<List<DocumentModel>>($"/business/{businessId}/document");
        }

        public DocumentModel Get(int businessId, int documentId)
        {
            return ApiRequest<DocumentModel>($"/business/{businessId}/document/{documentId}");
        }

        public DocumentFile Content(int businessId, int documentId)
        {
            return ApiByteArrayRequest<DocumentFile>($"/business/{businessId}/document/{documentId}/content");
        }

        public DocumentModel Create(int businessId, FileUploadModel document, bool visibleToAll = false, List<int> employeeGroups = null)
        {
            var result = ApiFileRequest<List<DocumentModel>>(
                $"/business/{businessId}/document?visibleToAll={visibleToAll}", document);
            if (employeeGroups == null || !employeeGroups.Any())
            {
                return result?.FirstOrDefault();
            }

            if (result?.FirstOrDefault() == null)
            {
                return null;
            }

            var id = result.First().Id;
            return ApiRequest<DocumentModel, dynamic>($"/business/{businessId}/document", new { id, visibleToAll, employeeGroups }, Method.PUT);
        }

        public List<DocumentModel> Create(int businessId, List<FileUploadModel> documents, bool visibleToAll = false, List<int> employeeGroups = null)
        {
            var result = ApiFileRequest<List<DocumentModel>>(
                $"/business/{businessId}/document?visibleToAll={visibleToAll}", documents);
            if (employeeGroups == null || !employeeGroups.Any())
            {
                return result;
            }

            if (result == null || !result.Any())
            {
                return null;
            }

            var docs = new List<DocumentModel>();
            foreach (var file in result)
            {
                var id = file.Id;
                docs.Add(ApiRequest<DocumentModel, dynamic>($"/business/{businessId}/document", new { id, visibleToAll, employeeGroups }, Method.PUT));
            }
            return docs;
        }

        public void Delete(int businessId, int id)
        {
            ApiRequest($"/business/{businessId}/document/{id}", Method.DELETE);
        }

        public DocumentModel Put(int businessId, int id, bool visibleToAll, List<int> employeeGroups)
        {
            var result = ApiRequest<DocumentModel, dynamic>($"/business/{businessId}/document", new { id, visibleToAll, employeeGroups }, Method.PUT);
            return result;
        }
    }
}