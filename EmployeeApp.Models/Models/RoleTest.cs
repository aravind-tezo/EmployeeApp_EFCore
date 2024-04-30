   public class RoleTest{
         public string Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public RoleTest(string id,string name,string department,string description,string location){
            Id=id;
            Name=name;
            Department=department;
            Location=location;
            Description=description;
        }
    }