import pandas as pd
import requests
import json

df = pd.read_csv("data/poke_genie_export.csv")


def writeEvolutionsToFile():
    evolutionList = createEvolutionList()
    with open("data/evolutions.txt", "w") as filehandle:
        json.dump(evolutionList, filehandle)


def readEvolutionsFromFile():
    evolutionListReadFromFile = []
    with open("data/evolutions.txt", "r") as filehandle:
        evolutionListReadFromFile = json.load(filehandle)
    return evolutionListReadFromFile


def onlyHighest(dataf):
    dataframeSorted = dataf.sort_values(by=['Name', 'Form', 'IV Avg'], ascending=[True, True, False])
    return dataframeSorted.drop_duplicates(subset=['Name', 'Form'])


def bestPvPPokemon(dataf, league):
    if league == "U" or league == "G" or league == "L":
        dataframeViable = dataf.dropna(subset=['Rank % (' + league + ')'])
        dataframeFiltered = dataframeViable[dataframeViable['Rank % (' + league + ')'] > '90.0%']
        dataframeSorted = dataframeFiltered.sort_values(
            by=['Name (' + league + ')', 'Form (' + league + ')', 'Rank % (' + league + ')'],
            ascending=[True, True, False])
        return dataframeSorted.drop_duplicates(subset=['Name (' + league + ')', 'Form (' + league + ')'])
    else:
        print("No valid league selected, please enter L, G or U.")


def createEvolutionList():
    allEvolutions = []
    for i in range(1, 539):  # 538 is the last entry at the moment
        print("Lookup for Number: " + str(i))
        evolution = []

        URL = "https://pokeapi.co/api/v2/evolution-chain/" + str(i) + "/"
        data = requests.get(url=URL)

        try:
            json_object = json.loads(data.text)

            firstStage = json_object['chain']['species']['name']
            secondStage = json_object['chain']['evolves_to']

            evolution.append(firstStage)
            for pokemon in secondStage:
                evolution.append(pokemon['species']['name'])

                thirdStage = pokemon['evolves_to']
                for pokemon2 in thirdStage:
                    evolution.append(pokemon2['species']['name'])

            if evolution not in allEvolutions:
                allEvolutions.append(evolution)

        except:
            print("Number " + str(i) + " was not found")

    return allEvolutions


def dfTestingArea():
    # dfTest = df
    dfTest = df.head(15)
    # dfTest = dfTest.sort_values(by=['Name', 'IV Avg'], ascending=[True, False])
    print(dfTest.dtypes)
    print(dfTest.to_string())
    print()
    print(bestPvPPokemon(dfTest, "U").to_string())
    print()
    print(bestPvPPokemon(dfTest, "G").to_string())
    print()
    print(bestPvPPokemon(dfTest, "L").to_string())


if __name__ == "__main__":
    # writeEvolutionsToFile()
    # print(readEvolutionsFromFile()[100])
    dfTestingArea()
    # print(createEvolutionList())
