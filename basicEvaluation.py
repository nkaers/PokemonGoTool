prio = ["IV", "UltraLeague", "GreatLeague", "LittleCup"]
numberOfStages = 0

# CP, Stage, IV, LittleCupIV, LittleCupTargetStage, GreatLeagueIV, GreatLeagueTargetStage, UltraLeagueIV,
# UltraLeagueTargetStage
pokemons = [[]]


def evaluateIV():
    best = []
    allIV = []
    for pokemon in pokemons:
        allIV.append(pokemon[2])
    for i in range(0, numberOfStages):
        position = allIV.index(max(allIV))
        best.append(pokemons[position])
        pokemons.pop(position)
        allIV.pop(position)
    return best


# TODO: check for target stage
def evaluateUltraLeague():
    best = []
    allIV = []
    for pokemon in pokemons:
        allIV.append(pokemon[7])
    for i in range(0, numberOfStages):
        position = allIV.index(max(allIV))
        best.append(pokemons[position])
        pokemons.pop(position)
        allIV.pop(position)
    return best


def evaluateGreatLeague():
    best = []
    allIV = []
    for pokemon in pokemons:
        allIV.append(pokemon[5])
    for i in range(0, numberOfStages):
        position = allIV.index(max(allIV))
        best.append(pokemons[position])
        pokemons.pop(position)
        allIV.pop(position)
    return best


def evaluateLittleCup():
    best = []
    allIV = []
    for pokemon in pokemons:
        allIV.append(pokemon[3])
    for i in range(0, numberOfStages):
        position = allIV.index(max(allIV))
        best.append(pokemons[position])
        pokemons.pop(position)
        allIV.pop(position)
    return best


if __name__ == "__main__":
    for attribute in prio:
        match attribute:
            case "IV":
                print(evaluateIV())

            case "UltraLeague":
                print(evaluateUltraLeague())

            case "GreatLeague":
                print(evaluateGreatLeague())

            case "LittleCup":
                print(evaluateLittleCup())
