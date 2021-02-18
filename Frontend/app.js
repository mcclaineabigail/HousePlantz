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

        let infoAside = document.createElement("aside");
        infoAside.classList.add("plant-info");
        let photo = document.createElement("img");
        photo.classList.add("image");
        photo.alt= ("Plant Image");
        photo.src = plant.image;
        let water = document.createElement("p")
        water.classList.add("water");
        water.innerText= plant.water;
        let notes = document.createElement("p")
        notes.classList.add("notes");
        notes.innerText= plant.notes;
        infoAside.appendChild(photo);
        infoAside.appendChild(water);
        infoAside.appendChild(notes);

        
        card.appendChild(titleAside);
        card.appendChild(infoAside);
        ownedSection.appendChild(card);
    });

    return ownedSection;
}