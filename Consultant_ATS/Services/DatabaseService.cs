using Consultant_ATS.Models;
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

        public List<Submission> GetSubmissions(string userId)
        {
            var submissionsCollection = _database.GetCollection<Submission>("Submissions");
            return submissionsCollection.Find(s => s.UserId == userId).ToList();
        }

        public Submission GetSubmissionByVendorDomain(string domain)
        {
            var submissionsCollection = _database.GetCollection<Submission>("Submissions");
            return submissionsCollection.Find(s => s.VendorEmail.Contains(domain)).FirstOrDefault();
        }

        public Submission GetSubmissionByVendorEmail(string vendorEmail)
        {
            var submissionsCollection = _database.GetCollection<Submission>("Submissions");
            return submissionsCollection.Find(s => s.VendorEmail == vendorEmail).FirstOrDefault();
        }

        public void UpdateSubmission(Submission submission)
        {
            var submissionsCollection = _database.GetCollection<Submission>("Submissions");
            submissionsCollection.ReplaceOne(s => s.Id == submission.Id, submission);
        }
    }

}
