import officeImage from "./office.jpg";

function App() {

  const officeList = [
    {
      Name: "DBS",
      Rent: 50000,
      Address: "Chennai"
    },
    {
      Name: "Regus",
      Rent: 75000,
      Address: "Bangalore"
    },
    {
      Name: "WeWork",
      Rent: 58000,
      Address: "Hyderabad"
    }
  ];

  return (
    <div>
      <h1>Office Space, at Affordable Range</h1>

      {officeList.map((office, index) => (
        <div key={index}>

          <img
            src={officeImage}
            alt="Office Space"
            width="25%"
            height="25%"
          />

          <h2>Name: {office.Name}</h2>

          <h3
            style={{
              color: office.Rent <= 60000 ? "red" : "green"
            }}
          >
            Rent Rs. {office.Rent}
          </h3>

          <h3>Address: {office.Address}</h3>

          <hr />

        </div>
      ))}
    </div>
  );
}

export default App;