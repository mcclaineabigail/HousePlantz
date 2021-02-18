fetch("https://plantcatalog.azurewebsites.net/api/plants", {
        method: "GET",
        
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((plants) => displayPlants(plants))
.catch((error) => console.log(error));



const displayPlants = function(plants) {
    const ownedSection = document.getElementById("owned")

    plants.forEach((plant) => {
        let card = document.createElement("div");
        card.classList.add("plant");
        

        let titleAside = document.createElement("aside");
        titleAside.classList.add("plant-header")

        let plantName = document.createElement("h2");
        plantName.classList.add("plant-name");
        plantName.innerText = plant.name;
        let sun = document.createElement("img");
        sun.src = plant.Sun;
        sun.alt= "light needs";
        sun.classList.add("sun");
        titleAside.appendChild(plantName);
        titleAside.appendChild(sun);
        
        card.appendChild(titleAside);
        ownedSection.appendChild(card);
    });

    return ownedSection;
}