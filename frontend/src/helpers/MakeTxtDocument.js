const MakeTxtDocument = (pokemonInfo) => {
    const takeAbilities = pokemonInfo.abilities.map((abilityIterative, index) => {
        if(index <=3) {
            return abilityIterative.ability.name.toUpperCase();
        }
    });

    const stringInfo= `
     NAME: ${pokemonInfo.name.toUpperCase()}, 
     TYPE: ${pokemonInfo.types[0].type.name.toUpperCase()}, 
     ABILITIES: ${JSON.stringify(takeAbilities)}, 
     ATTACK: ${pokemonInfo.moves[0].move.name.toUpperCase()}     
    `
    const blob = new Blob([stringInfo], { type: "text/plain" });
      const link = document.createElement("a");
      link.href = URL.createObjectURL(blob);
      link.download = `${pokemonInfo.name.toUpperCase()}-Pokemon-Data`;
      link.click();
      URL.revokeObjectURL(link.href); 
}

export default MakeTxtDocument;