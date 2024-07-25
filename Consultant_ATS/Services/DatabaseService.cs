using Consultant_ATS.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Consultant_ATS.Services
{
    public class DatabaseService
    {
        private readonly IMongoDatabase _database;

        public DatabaseService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("ConsultantATS");
        }

        public void CreateUser(User user)
        {
            var usersCollection = _database.GetCollection<User>("Users");
            usersCollection.InsertOne(user);
        }

        public User GetUser(string email, string password)
        {
            var usersCollection = _database.GetCollection<User>("Users");
            return usersCollection.Find(u => u.Email == email && u.Password == password).FirstOrDefault();
        }

        public void CreateSubmission(Submission submission)
        {
            var submissionsCollection = _database.GetCollection<Submission>("Submissions");
            submissionsCollection.InsertOne(submission);
        }
        // Add this method to your DatabaseService class
        public List<Submission> GetSubmissionsByVendorCompany(string userId, string vendorCompany)
        {
            var submissionsCollection = _database.GetCollection<Submission>("Submissions");

            // Create a case-insensitive regex filter for vendorCompany
            var vendorCompanyFilter = Builders<Submission>.Filter.Regex(
                "VendorCompany",
                new BsonRegularExpression($"^{vendorCompany}$", "i")
            );

            // Create the filter for userId and combine it with the vendorCompany filter
            var userIdFilter = Builders<Submission>.Filter.Eq("UserId", userId);
            var combinedFilter = Builders<Submission>.Filter.And(userIdFilter, vendorCompanyFilter);

            // Execute the query with the combined filter
            return submissionsCollection.Find(combinedFilter).ToList();
        }



        public List<Submission> GetSubmissions(string userId)
        {
            var submissionsCollection = _database.GetCollection<Submission>("Submissions");
            return submissionsCollection.Find(s => s.UserId == userId).ToList();
        }


        public void UpdateSubmission(Submission submission)
        {
            var submissionsCollection = _database.GetCollection<Submission>("Submissions");
            submissionsCollection.ReplaceOne(s => s.Id == submission.Id, submission);
        }
        public void DeleteSubmission(string id)
        {
            var submissionsCollection = _database.GetCollection<Submission>("Submissions");
            submissionsCollection.DeleteOne(s => s.Id == new ObjectId(id));
        }
        public List<Submission> GetSubmissionsByVendorEmail(string vendorEmail)
        {
            var submissionsCollection = _database.GetCollection<Submission>("Submissions");
            return submissionsCollection.Find(s => s.VendorEmail == vendorEmail).ToList();
        }



    }

}
