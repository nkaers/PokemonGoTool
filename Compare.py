import pandas as pd
import requests
import json

df = pd.read_csv("data/poke_genie_export.csv")


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
    dataframeViable = dataf.dropna(subset=['Rank % (' + league + ')'])
    dataframeFiltered = dataframeViable[dataframeViable['Rank % (' + league + ')'] > '90.0%']
    dataframeSorted = dataframeFiltered.sort_values(
        by=['Name (' + league + ')', 'Form (' + league + ')', 'Rank % (' + league + ')'],
        ascending=[True, True, False])
    return dataframeSorted.drop_duplicates(subset=['Name (' + league + ')', 'Form (' + league + ')'])


def createPvPData(dataf):
    differentLeagues = []
    for league in ["U", "G", "L"]:
        differentLeagues.append(bestPvPPokemon(dataf, league))
        # include all Pokemon with a PvP stat of 98% or higher just to be sure to not delete good Pokemon
        # TODO: improve filtering to avoid doing this
        differentLeagues.append(dataf[dataf['Rank % (' + league + ')'] > '98.0%'])
    # hint: this shows what items of df2 are missing in df1
    #print(pd.concat([df1, df2, df1]).drop_duplicates(keep=False).sort_values(by='Index').to_string())
    #print((pd.concat([df1, df2, df1]).drop_duplicates(keep=False)).shape)
    return pd.concat(differentLeagues).drop_duplicates()


def dfTestingArea():
    #dfTest = df
    dfTest = df.head(50)
    #print(dfTest.dtypes)
    #print(dfTest.to_string())
    print(createPvPData(dfTest).to_string())
    print(createPvPData(dfTest).shape)


if __name__ == "__main__":
    # writeEvolutionsToFile()
    # print(readEvolutionsFromFile()[100])
    dfTestingArea()
    # print(createEvolutionList())
