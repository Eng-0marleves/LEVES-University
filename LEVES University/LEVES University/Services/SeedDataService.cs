using LEVES_University.Interfaces;
using LEVES_University.DBContext;
using LEVES_University.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LEVES_University.Services
{
    public class SeedDataService : ISeedDataService
    {
        private readonly LevesEntities _dbContext;

        public SeedDataService(LevesEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedRolesAsync()
        {
            string[] rolesToAdd = { "student", "doctor", "manager", "admin", "librarian" };

            foreach (var roleName in rolesToAdd)
            {
                var existingRole = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
                if (existingRole == null)
                {
                    var role = new Role { Name = roleName };
                    _dbContext.Roles.Add(role);
                }
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task SeedUsersAsync()
        {
            List<Users> users = new List<Users>
            {
                //new Users { Id = "1234567890", RoleId = 2, NTID = 2326266155, FirstName = "Gomez", LastName = "Addams", Email = "gomez@example.com", PhoneNumber = "123-456-7890", Password = "1234567890", IsActive = true },
                //new Users { Id = "1234567891", RoleId = 4, NTID = 9455234145, FirstName = "Morticia", LastName = "Addams", Email = "morticia@example.com", PhoneNumber = "111-222-3333", Password = "1234567891", IsActive = true },
                //new Users { Id = "1234567892", RoleId = 4, NTID = 6562856556, FirstName = "Pugsley", LastName = "Addams", Email = "pugsley@example.com", PhoneNumber = "444-555-6666", Password = "password1", IsActive = true }
            };

            await _dbContext.Users.AddRangeAsync(users);

            await _dbContext.SaveChangesAsync();
        }


        public async Task SeedCollegesAsync()
        {
            var colleges = new List<College>
            {
                new College { Name = "Engineering" },
                new College { Name = "Journalism" },
                new College { Name = "Business" },
                new College { Name = "Arts and Sciences" },
            };

            foreach (var college in colleges)
            {
                var existingCollege = await _dbContext.Colleges.FirstOrDefaultAsync(c => c.Name == college.Name);
                if (existingCollege == null)
                {
                    _dbContext.Colleges.Add(college);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }


        public async Task SeedAreasOfStudyAsync()
        {
            var areasOfStudy = new List<AreaOfStudy>
            {
                new AreaOfStudy { StudyTitle = "Computer Science", CollegeId = 1 },
                new AreaOfStudy { StudyTitle = "Electrical Engineering", CollegeId = 1 },
                new AreaOfStudy { StudyTitle = "Finance", CollegeId = 2 },
                new AreaOfStudy { StudyTitle = "Marketing", CollegeId = 2 },
                new AreaOfStudy { StudyTitle = "Biology", CollegeId = 3 },
                new AreaOfStudy { StudyTitle = "History", CollegeId = 3 },
            };

            foreach (var areaOfStudy in areasOfStudy)
            {
                var existingAreaOfStudy = await _dbContext.AreasOfStudy.FirstOrDefaultAsync(a => a.StudyTitle == areaOfStudy.StudyTitle);
                if (existingAreaOfStudy == null)
                {
                    _dbContext.AreasOfStudy.Add(areaOfStudy);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }


        public async Task SeedCoursesAsync()
        {
            _dbContext.CoursesCatalogues.RemoveRange(_dbContext.CoursesCatalogues);

            await _dbContext.SaveChangesAsync();

            var computerScienceCourses = new List<CourseCatalogue>
            {
                new CourseCatalogue { CourseCode = "CSCI101", CourseTitle = "Introduction to Computer Science", CourseDescription = "An introductory course covering fundamental concepts of computer science.", CreditHours = 3 },
                new CourseCatalogue { CourseCode = "CSCI201", CourseTitle = "Data Structures and Algorithms", CourseDescription = "A course focusing on data structures and algorithms.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "CSCI301", CourseTitle = "Computer Architecture", CourseDescription = "Study of computer architecture and organization.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "CSCI401", CourseTitle = "Operating Systems", CourseDescription = "Introduction to operating system principles and design.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "CSCI501", CourseTitle = "Database Systems", CourseDescription = "Fundamentals of database systems and management.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "CSCI601", CourseTitle = "Software Engineering", CourseDescription = "Principles and practices of software engineering.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "CSCI701", CourseTitle = "Artificial Intelligence", CourseDescription = "Introduction to artificial intelligence techniques and applications.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "CSCI801", CourseTitle = "Machine Learning", CourseDescription = "Study of algorithms that improve automatically through experience.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "CSCI901", CourseTitle = "Computer Graphics", CourseDescription = "Introduction to computer graphics algorithms and techniques.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "CSCI1001", CourseTitle = "Cybersecurity", CourseDescription = "Fundamentals of cybersecurity principles and practices.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "CSCI1101", CourseTitle = "Web Development", CourseDescription = "Introduction to web development technologies and frameworks.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "CSCI1201", CourseTitle = "Parallel and Distributed Computing", CourseDescription = "Study of parallel computing architectures and algorithms.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "CSCI1301", CourseTitle = "Cloud Computing", CourseDescription = "Introduction to cloud computing concepts and platforms.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "CSCI1401", CourseTitle = "Natural Language Processing", CourseDescription = "Study of computational methods for processing human language.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "CSCI1501", CourseTitle = "Big Data Analytics", CourseDescription = "Introduction to big data processing and analytics techniques.", CreditHours = 8 },
                new CourseCatalogue { CourseCode = "CSCI1601", CourseTitle = "Computer Vision", CourseDescription = "Introduction to computer vision algorithms and applications.", CreditHours = 7 },
            };

            var electricalEngineeringCourses = new List<CourseCatalogue>
            {
                new CourseCatalogue { CourseCode = "ELEC101", CourseTitle = "Electrical Engineering Fundamentals", CourseDescription = "An introductory course to electrical engineering principles.", CreditHours = 3 },
                new CourseCatalogue { CourseCode = "ELEC301", CourseTitle = "Power Systems", CourseDescription = "A course covering power systems and distribution.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "ELEC401", CourseTitle = "Electromagnetic Fields", CourseDescription = "Study of electromagnetic theory and applications.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "ELEC501", CourseTitle = "Digital Electronics", CourseDescription = "Introduction to digital electronic circuits and systems.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "ELEC601", CourseTitle = "Analog Electronics", CourseDescription = "Study of analog electronic circuits and systems.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "ELEC701", CourseTitle = "Control Systems", CourseDescription = "Introduction to control systems engineering principles.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "ELEC801", CourseTitle = "Power Electronics", CourseDescription = "Study of power electronic converters and applications.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "ELEC901", CourseTitle = "Renewable Energy Systems", CourseDescription = "Introduction to renewable energy sources and systems.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "ELEC1001", CourseTitle = "Electric Drives", CourseDescription = "Study of electric drive systems and applications.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "ELEC1101", CourseTitle = "Signal Processing", CourseDescription = "Introduction to digital signal processing techniques.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "ELEC1201", CourseTitle = "Communication Systems", CourseDescription = "Study of analog and digital communication systems.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "ELEC1301", CourseTitle = "Microelectronics", CourseDescription = "Introduction to microelectronic devices and circuits.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "ELEC1401", CourseTitle = "Power System Protection", CourseDescription = "Study of power system protection devices and schemes.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "ELEC1501", CourseTitle = "High Voltage Engineering", CourseDescription = "Introduction to high voltage engineering principles and applications.", CreditHours = 8 },
                new CourseCatalogue { CourseCode = "ELEC1601", CourseTitle = "Embedded Systems", CourseDescription = "Study of embedded system design and programming.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "ELEC1701", CourseTitle = "Renewable Energy Integration", CourseDescription = "Introduction to integration of renewable energy sources into power grids.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "ELEC1801", CourseTitle = "Electric Power Distribution", CourseDescription = "Study of electric power distribution systems and components.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "ELEC1901", CourseTitle = "Smart Grid Technologies", CourseDescription = "Introduction to smart grid concepts and technologies.", CreditHours = 8 }
            };

            var commonEngineeringCourses = new List<CourseCatalogue>
            {
                new CourseCatalogue { CourseCode = "PHYS101", CourseTitle = "Physics I", CourseDescription = "Introduction to classical mechanics, including kinematics, dynamics, and energy.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "PHYS201", CourseTitle = "Physics II", CourseDescription = "Continuation of Physics I, covering electricity, magnetism, and optics.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "MATH101", CourseTitle = "Calculus I", CourseDescription = "Introduction to differential and integral calculus.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "MATH201", CourseTitle = "Calculus II", CourseDescription = "Continuation of Calculus I, covering techniques of integration and applications.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "CHEM101", CourseTitle = "Chemistry I", CourseDescription = "Introduction to basic principles of chemistry.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "CHEM201", CourseTitle = "Chemistry II", CourseDescription = "Continuation of Chemistry I, covering chemical kinetics, thermodynamics, and equilibrium.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "BIOL101", CourseTitle = "Biology I", CourseDescription = "Introduction to fundamental principles of biology.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "BIOL201", CourseTitle = "Biology II", CourseDescription = "Continuation of Biology I, covering cellular and molecular biology.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "ENGL101", CourseTitle = "English Composition", CourseDescription = "Study of effective writing techniques and strategies.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "ENGL201", CourseTitle = "World Literature", CourseDescription = "Introduction to world literature from various cultures and periods.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "HIST101", CourseTitle = "World History", CourseDescription = "Introduction to world history from ancient civilizations to modern times.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "PSYC101", CourseTitle = "Introduction to Psychology", CourseDescription = "Introduction to basic principles of psychology.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "SOC101", CourseTitle = "Introduction to Sociology", CourseDescription = "Introduction to basic principles of sociology.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "PHIL101", CourseTitle = "Introduction to Philosophy", CourseDescription = "Introduction to basic principles of philosophy.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "ART101", CourseTitle = "Introduction to Art History", CourseDescription = "Introduction to basic principles of art history and appreciation.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "LING101", CourseTitle = "Introduction to Linguistics", CourseDescription = "Introduction to basic principles of linguistics and language analysis.", CreditHours = 4 }
            };











            var financeCourses = new List<CourseCatalogue>
            {
                new CourseCatalogue { CourseCode = "FINC101", CourseTitle = "Principles of Finance", CourseDescription = "An introductory course to finance principles.", CreditHours = 3 },
                new CourseCatalogue { CourseCode = "FINC401", CourseTitle = "Investment Analysis", CourseDescription = "A course focusing on investment analysis and portfolio management.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "FINC501", CourseTitle = "Corporate Finance", CourseDescription = "Study of financial decisions within corporations.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "FINC601", CourseTitle = "Financial Markets and Institutions", CourseDescription = "Introduction to financial markets and institutions.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "FINC701", CourseTitle = "Derivatives and Risk Management", CourseDescription = "Study of derivative instruments and risk management techniques.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "FINC801", CourseTitle = "Behavioral Finance", CourseDescription = "Introduction to behavioral aspects of financial decision making.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "FINC901", CourseTitle = "International Finance", CourseDescription = "Study of financial management in a global context.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "FINC1001", CourseTitle = "Financial Modeling", CourseDescription = "Introduction to financial modeling techniques and applications.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "FINC1101", CourseTitle = "Fixed Income Securities", CourseDescription = "Study of fixed income securities and valuation methods.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "FINC1201", CourseTitle = "Portfolio Management", CourseDescription = "Introduction to portfolio management strategies and techniques.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "FINC1301", CourseTitle = "Advanced Investment Strategies", CourseDescription = "Study of advanced investment strategies and techniques.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "FINC1401", CourseTitle = "Financial Statement Analysis", CourseDescription = "Introduction to financial statement analysis techniques.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "FINC1501", CourseTitle = "Venture Capital and Private Equity", CourseDescription = "Study of venture capital and private equity financing.", CreditHours = 8 },
                new CourseCatalogue { CourseCode = "FINC1601", CourseTitle = "Financial Econometrics", CourseDescription = "Introduction to econometric methods in finance.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "FINC1701", CourseTitle = "Mergers and Acquisitions", CourseDescription = "Study of mergers, acquisitions, and corporate restructuring.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "FINC1801", CourseTitle = "Financial Risk Modeling", CourseDescription = "Introduction to financial risk modeling techniques.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "FINC1901", CourseTitle = "Financial Engineering", CourseDescription = "Study of engineering techniques applied to financial markets.", CreditHours = 8 }
            };

            var journalismCourses = new List<CourseCatalogue>
            {
                new CourseCatalogue { CourseCode = "JOUR101", CourseTitle = "Introduction to Journalism", CourseDescription = "An introductory course to journalism principles.", CreditHours = 3 },
                new CourseCatalogue { CourseCode = "JOUR301", CourseTitle = "Media Ethics", CourseDescription = "A course focusing on ethical issues in media.", CreditHours = 3 },
                new CourseCatalogue { CourseCode = "JOUR401", CourseTitle = "News Reporting", CourseDescription = "Study of news gathering and reporting techniques.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "JOUR501", CourseTitle = "Feature Writing", CourseDescription = "Introduction to feature writing for newspapers and magazines.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "JOUR601", CourseTitle = "Broadcast Journalism", CourseDescription = "Study of broadcast journalism techniques for radio and television.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "JOUR701", CourseTitle = "Investigative Journalism", CourseDescription = "Introduction to investigative journalism methods and practices.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "JOUR801", CourseTitle = "Digital Journalism", CourseDescription = "Study of journalism in the digital age, including online reporting and social media.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "JOUR901", CourseTitle = "Photojournalism", CourseDescription = "Introduction to photojournalism techniques and ethics.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "JOUR1001", CourseTitle = "Magazine Editing and Production", CourseDescription = "Study of magazine editing and production processes.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "JOUR1101", CourseTitle = "Documentary Filmmaking", CourseDescription = "Introduction to documentary filmmaking techniques.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "JOUR1201", CourseTitle = "Multimedia Journalism", CourseDescription = "Study of multimedia storytelling techniques for online platforms.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "JOUR1301", CourseTitle = "Global Journalism", CourseDescription = "Introduction to international journalism and reporting.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "JOUR1401", CourseTitle = "Sports Journalism", CourseDescription = "Study of sports reporting and journalism ethics in sports media.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "JOUR1501", CourseTitle = "Editorial Writing", CourseDescription = "Introduction to editorial writing and opinion journalism.", CreditHours = 8 },
                new CourseCatalogue { CourseCode = "JOUR1601", CourseTitle = "Data Journalism", CourseDescription = "Study of data-driven journalism techniques and practices.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "JOUR1701", CourseTitle = "Cultural Journalism", CourseDescription = "Introduction to cultural reporting and criticism.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "JOUR1801", CourseTitle = "Investigative Reporting Techniques", CourseDescription = "Study of advanced investigative reporting techniques.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "JOUR1901", CourseTitle = "Media Law and Ethics", CourseDescription = "Introduction to legal and ethical issues in journalism.", CreditHours = 8 }
            };

            var marketingCourses = new List<CourseCatalogue>
            {
                new CourseCatalogue { CourseCode = "MKTG101", CourseTitle = "Introduction to Marketing", CourseDescription = "An introductory course covering fundamental concepts of marketing.", CreditHours = 3 },
                new CourseCatalogue { CourseCode = "MKTG201", CourseTitle = "Consumer Behavior", CourseDescription = "Study of consumer behavior and decision-making processes.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "MKTG301", CourseTitle = "Marketing Research", CourseDescription = "Introduction to marketing research methods and techniques.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "MKTG401", CourseTitle = "Marketing Strategy", CourseDescription = "Study of strategic marketing planning and implementation.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "MKTG501", CourseTitle = "Brand Management", CourseDescription = "Introduction to brand management principles and practices.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "MKTG601", CourseTitle = "Digital Marketing", CourseDescription = "Study of marketing strategies and tactics in digital environments.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "MKTG701", CourseTitle = "Marketing Analytics", CourseDescription = "Introduction to marketing analytics tools and techniques.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "MKTG801", CourseTitle = "Social Media Marketing", CourseDescription = "Study of social media marketing strategies and platforms.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "MKTG901", CourseTitle = "Global Marketing", CourseDescription = "Introduction to marketing strategies in global markets.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "MKTG1001", CourseTitle = "Advertising Management", CourseDescription = "Study of advertising principles and campaign management.", CreditHours = 8 },
                new CourseCatalogue { CourseCode = "MKTG1101", CourseTitle = "Retail Management", CourseDescription = "Introduction to retail management principles and practices.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "MKTG1201", CourseTitle = "Sales Management", CourseDescription = "Study of sales management strategies and techniques.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "MKTG1301", CourseTitle = "E-commerce Marketing", CourseDescription = "Introduction to marketing strategies for e-commerce businesses.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "MKTG1401", CourseTitle = "Product Management", CourseDescription = "Study of product management principles and techniques.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "MKTG1501", CourseTitle = "Event Marketing", CourseDescription = "Introduction to event marketing strategies and planning.", CreditHours = 8 },
                new CourseCatalogue { CourseCode = "MKTG1601", CourseTitle = "Public Relations", CourseDescription = "Study of public relations principles and practices.", CreditHours = 5 }
            };

            var businessCourses = new List<CourseCatalogue>
            {
                new CourseCatalogue { CourseCode = "BUS101", CourseTitle = "Introduction to Business", CourseDescription = "An introductory course to business principles.", CreditHours = 3 },
                new CourseCatalogue { CourseCode = "BUS401", CourseTitle = "Strategic Management", CourseDescription = "A course focusing on strategic planning and management.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "BUS501", CourseTitle = "Marketing Management", CourseDescription = "Study of marketing strategies and tactics.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "BUS601", CourseTitle = "Operations Management", CourseDescription = "Introduction to operations management principles.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "BUS701", CourseTitle = "Human Resource Management", CourseDescription = "Study of human resource management practices and policies.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "BUS801", CourseTitle = "Financial Management", CourseDescription = "Introduction to financial management principles.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "BUS901", CourseTitle = "Business Ethics", CourseDescription = "Study of ethical issues in business.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "BUS1001", CourseTitle = "Entrepreneurship", CourseDescription = "Introduction to entrepreneurship and small business management.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "BUS1101", CourseTitle = "Business Law", CourseDescription = "Study of legal issues affecting businesses.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "BUS1201", CourseTitle = "Supply Chain Management", CourseDescription = "Introduction to supply chain management concepts and practices.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "BUS1301", CourseTitle = "Business Communication", CourseDescription = "Study of effective business communication strategies.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "BUS1401", CourseTitle = "International Business", CourseDescription = "Introduction to international business environments and strategies.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "BUS1501", CourseTitle = "Business Analytics", CourseDescription = "Study of data analytics techniques for business decision-making.", CreditHours = 8 },
                new CourseCatalogue { CourseCode = "BUS1601", CourseTitle = "Strategic Marketing", CourseDescription = "Introduction to strategic marketing planning and implementation.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "BUS1701", CourseTitle = "Organizational Behavior", CourseDescription = "Study of individual and group behavior in organizational settings.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "BUS1801", CourseTitle = "Business Strategy", CourseDescription = "Introduction to strategic management concepts and frameworks.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "BUS1901", CourseTitle = "Corporate Governance", CourseDescription = "Study of corporate governance mechanisms and practices.", CreditHours = 8 }
            };

            var biologyCourses = new List<CourseCatalogue>
            {
                new CourseCatalogue { CourseCode = "BIOL101", CourseTitle = "Introduction to Biology", CourseDescription = "An introductory course covering fundamental concepts of biology.", CreditHours = 3 },
                new CourseCatalogue { CourseCode = "BIOL201", CourseTitle = "Cell Biology", CourseDescription = "Study of the structure and function of cells.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "BIOL301", CourseTitle = "Genetics", CourseDescription = "Introduction to principles of genetics and inheritance.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "BIOL401", CourseTitle = "Ecology", CourseDescription = "Study of interactions between organisms and their environment.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "BIOL501", CourseTitle = "Evolutionary Biology", CourseDescription = "Introduction to principles of evolutionary theory.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "BIOL601", CourseTitle = "Microbiology", CourseDescription = "Study of microorganisms and their applications.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "BIOL701", CourseTitle = "Anatomy and Physiology", CourseDescription = "Introduction to the structure and function of the human body.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "BIOL801", CourseTitle = "Neurobiology", CourseDescription = "Study of the nervous system and neural processes.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "BIOL901", CourseTitle = "Biochemistry", CourseDescription = "Introduction to biochemical principles and processes.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "BIOL1001", CourseTitle = "Immunology", CourseDescription = "Study of the immune system and immune responses.", CreditHours = 8 },
                new CourseCatalogue { CourseCode = "BIOL1101", CourseTitle = "Botany", CourseDescription = "Introduction to plant biology and physiology.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "BIOL1201", CourseTitle = "Zoology", CourseDescription = "Study of animal biology and diversity.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "BIOL1301", CourseTitle = "Environmental Biology", CourseDescription = "Introduction to environmental biology and conservation.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "BIOL1401", CourseTitle = "Molecular Biology", CourseDescription = "Study of molecular processes in living organisms.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "BIOL1501", CourseTitle = "Developmental Biology", CourseDescription = "Introduction to principles of developmental biology.", CreditHours = 8 },
                new CourseCatalogue { CourseCode = "BIOL1601", CourseTitle = "Biotechnology", CourseDescription = "Study of biological techniques and applications in industry.", CreditHours = 5 }
            };

            var historyCourses = new List<CourseCatalogue>
            {
                new CourseCatalogue { CourseCode = "HIST101", CourseTitle = "Introduction to World History", CourseDescription = "An introductory course covering fundamental concepts of world history.", CreditHours = 3 },
                new CourseCatalogue { CourseCode = "HIST201", CourseTitle = "Ancient History", CourseDescription = "Study of ancient civilizations and their contributions to world history.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "HIST301", CourseTitle = "Medieval History", CourseDescription = "Study of medieval Europe and other medieval civilizations.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "HIST401", CourseTitle = "Renaissance and Reformation", CourseDescription = "Introduction to the Renaissance and Reformation periods.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "HIST501", CourseTitle = "Early Modern History", CourseDescription = "Study of early modern Europe and other early modern civilizations.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "HIST601", CourseTitle = "Modern History", CourseDescription = "Introduction to modern world history from the late 18th century to the present.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "HIST701", CourseTitle = "History of the United States", CourseDescription = "Study of the history of the United States from colonial times to the present.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "HIST801", CourseTitle = "History of Asia", CourseDescription = "Introduction to the history of Asia and its civilizations.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "HIST901", CourseTitle = "History of Africa", CourseDescription = "Study of the history of Africa and its civilizations.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "HIST1001", CourseTitle = "History of Latin America", CourseDescription = "Introduction to the history of Latin America and its civilizations.", CreditHours = 8 },
                new CourseCatalogue { CourseCode = "HIST1101", CourseTitle = "History of the Middle East", CourseDescription = "Study of the history of the Middle East and its civilizations.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "HIST1201", CourseTitle = "History of Europe", CourseDescription = "Introduction to the history of Europe and its civilizations.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "HIST1301", CourseTitle = "History of Science and Technology", CourseDescription = "Study of the history of science, technology, and innovation.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "HIST1401", CourseTitle = "Military History", CourseDescription = "Introduction to the history of warfare and military institutions.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "HIST1501", CourseTitle = "Social and Cultural History", CourseDescription = "Study of social and cultural developments in world history.", CreditHours = 8 },
                new CourseCatalogue { CourseCode = "HIST1601", CourseTitle = "Historiography", CourseDescription = "Introduction to the theory and methods of historical research.", CreditHours = 5 }
            };

            var artsAndSciencesCourses = new List<CourseCatalogue>
            {
                new CourseCatalogue { CourseCode = "ARTS101", CourseTitle = "Introduction to Arts and Sciences", CourseDescription = "An introductory course to arts and sciences.", CreditHours = 3 },
                new CourseCatalogue { CourseCode = "ARTS301", CourseTitle = "Critical Thinking", CourseDescription = "A course focusing on developing critical thinking skills.", CreditHours = 3 },
                new CourseCatalogue { CourseCode = "ARTS401", CourseTitle = "Ethics in Society", CourseDescription = "Study of ethical issues in contemporary society.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "ARTS501", CourseTitle = "World History", CourseDescription = "Introduction to world history from ancient civilizations to modern times.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "ARTS601", CourseTitle = "Literature and Culture", CourseDescription = "Study of literature and its cultural contexts.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "ARTS701", CourseTitle = "Environmental Science", CourseDescription = "Introduction to environmental science concepts and issues.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "ARTS801", CourseTitle = "Psychology", CourseDescription = "Introduction to psychology principles and theories.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "ARTS901", CourseTitle = "Sociology", CourseDescription = "Introduction to sociology concepts and methods.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "ARTS1001", CourseTitle = "Political Science", CourseDescription = "Introduction to political science theories and systems.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "ARTS1101", CourseTitle = "Economics", CourseDescription = "Introduction to economic principles and theories.", CreditHours = 4 },
                new CourseCatalogue { CourseCode = "ARTS1201", CourseTitle = "Philosophy", CourseDescription = "Introduction to philosophical ideas and arguments.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "ARTS1301", CourseTitle = "Anthropology", CourseDescription = "Introduction to anthropological concepts and methods.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "ARTS1401", CourseTitle = "Geography", CourseDescription = "Introduction to geographic principles and spatial analysis.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "ARTS1501", CourseTitle = "Creative Writing", CourseDescription = "Introduction to creative writing techniques and genres.", CreditHours = 8 },
                new CourseCatalogue { CourseCode = "ARTS1601", CourseTitle = "Statistics", CourseDescription = "Introduction to statistical methods and data analysis.", CreditHours = 5 },
                new CourseCatalogue { CourseCode = "ARTS1701", CourseTitle = "Public Speaking", CourseDescription = "Study of effective public speaking techniques.", CreditHours = 6 },
                new CourseCatalogue { CourseCode = "ARTS1801", CourseTitle = "Cultural Studies", CourseDescription = "Study of culture and its impact on society.", CreditHours = 7 },
                new CourseCatalogue { CourseCode = "ARTS1901", CourseTitle = "Research Methods", CourseDescription = "Introduction to research methods in social sciences and humanities.", CreditHours = 8 }
            };


            _dbContext.CoursesCatalogues.AddRange(computerScienceCourses);
            _dbContext.CoursesCatalogues.AddRange(electricalEngineeringCourses);
            _dbContext.CoursesCatalogues.AddRange(financeCourses);
            _dbContext.CoursesCatalogues.AddRange(journalismCourses);
            _dbContext.CoursesCatalogues.AddRange(marketingCourses);
            _dbContext.CoursesCatalogues.AddRange(businessCourses);
            _dbContext.CoursesCatalogues.AddRange(biologyCourses);
            _dbContext.CoursesCatalogues.AddRange(historyCourses);
            _dbContext.CoursesCatalogues.AddRange(artsAndSciencesCourses);
            _dbContext.CoursesCatalogues.AddRange(commonEngineeringCourses);

            await _dbContext.SaveChangesAsync();
            
        }


        public async Task SeedStudentsAsync()
        {
            var students = new List<Users>
            {
                new Users() { RoleId = 1, NTID = 1234567890, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890", IsActive = true },
                new Users() { RoleId = 1, NTID = 2345678901, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "234-567-8901", IsActive = true },
                new Users() { RoleId = 1, NTID = 3456789012, FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", PhoneNumber = "345-678-9012", IsActive = true },
                new Users() { RoleId = 1, NTID = 4567890123, FirstName = "Emily", LastName = "Brown", Email = "emily.brown@example.com", PhoneNumber = "456-789-0123", IsActive = true },
                new Users() { RoleId = 1, NTID = 5678901234, FirstName = "Daniel", LastName = "Martinez", Email = "daniel.martinez@example.com", PhoneNumber = "567-890-1234", IsActive = true },
                new Users() { RoleId = 1, NTID = 6789012345, FirstName = "Olivia", LastName = "Taylor", Email = "olivia.taylor@example.com", PhoneNumber = "678-901-2345", IsActive = true },
                new Users() { RoleId = 1, NTID = 7890123456, FirstName = "William", LastName = "Anderson", Email = "william.anderson@example.com", PhoneNumber = "789-012-3456", IsActive = true },
                new Users() { RoleId = 1, NTID = 8901234567, FirstName = "Sophia", LastName = "Thomas", Email = "sophia.thomas@example.com", PhoneNumber = "890-123-4567", IsActive = true },
                new Users() { RoleId = 1, NTID = 9012345678, FirstName = "James", LastName = "Hernandez", Email = "james.hernandez@example.com", PhoneNumber = "901-234-5678", IsActive = true },
                new Users() { RoleId = 1, NTID = 1123456789, FirstName = "Isabella", LastName = "Young", Email = "isabella.young@example.com", PhoneNumber = "112-345-6789", IsActive = true }
            };

            await _dbContext.Users.AddRangeAsync(students);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<CourseCatalogue>> GetCoursesAsync()
        {
            var courses = await _dbContext.CoursesCatalogues.ToListAsync();
            return courses;
        }


    }
}
