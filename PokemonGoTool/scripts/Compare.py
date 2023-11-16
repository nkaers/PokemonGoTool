import pandas as pd
import requests
import json

from pandas import isnull

# TODO check for same pokemon on different level since they appear multiple times if scanned

df = pd.read_csv("../data/poke_genie_export.csv")


def createEvolutionList():
    allEvolutions = []  # array to store the whole set
    for i in range(1, 539):  # 538 is the last entry at the moment
        print("Lookup for Number: " + str(i))
        evolution = []

        URL = "https://pokeapi.co/api/v2/evolution-chain/" + str(i) + "/"  # URL of the Pokemon API
        data = requests.get(url=URL)

        try:
            json_object = json.loads(data.text)  # extract the data as texts since json returned an error

            # get the name of the first stage pokemon
            # it will always return the first stage since the query does not handle pokemon individually
            firstStage = json_object['chain']['species']['name']
            evolution.append(firstStage.title())

            # create a list of Pokemon in which the first stage is able to evolve into
            secondStage = json_object['chain']['evolves_to']

            for pokemon in secondStage:
                # add every possible evolution to the list
                # usually only one but there are cases like Eevee
                evolution.append((pokemon['species']['name']).title())

                # same procedure as with the second stage
                thirdStage = pokemon['evolves_to']
                for pokemon2 in thirdStage:
                    evolution.append((pokemon2['species']['name']).title())

            # to not allow duplicates check if the line is already added
            # should never fail because of the structure of the API
            if evolution not in allEvolutions:
                allEvolutions.append(evolution)

        except:
            print("Number " + str(i) + " was not found")

    return allEvolutions


def writeEvolutionsToFile():
    evolutionList = createEvolutionList()
    with open("../data/evolutions.txt", "w") as filehandle:
        json.dump(evolutionList, filehandle)


def readEvolutionsFromFile():
    evolutionListReadFromFile = []
    with open("../data/evolutions.txt", "r") as filehandle:
        evolutionListReadFromFile = json.load(filehandle)
    return evolutionListReadFromFile


def bestPvEPokemon(dataf):
    # list to store all the dataframes with the Pokemon who are kept
    allPokemon = []

    # read the evolution line information from the file or generate them if empty
    try:
        evolutions = readEvolutionsFromFile()
    except:
        writeEvolutionsToFile()
        evolutions = readEvolutionsFromFile()

    # for every evolution line which can be found in the file
    for evolutionLine in evolutions:
        # check how many stages the evolution line has
        stages = len(evolutionLine)
        # extract all Pokemon corresponding to the evolution line we are looking at and sort them
        pokemon = dataf.loc[dataf['Name'].isin(evolutionLine)].sort_values(by=['Form', 'IV Avg'],
                                                                           ascending=[True, False])
        # because of multiple forms just taking the best ones is not good enough
        # extract all the possible forms the Pokemon has
        forms = pokemon['Form'].drop_duplicates()
        for form in forms:
            if isnull(form):
                pokemonWithForm = pokemon[pokemon['Form'].isnull()].head(stages)
                allPokemon.append(pokemonWithForm)
                break
            pokemonWithForm = pokemon[pokemon['Form'] == form].head(stages)
            allPokemon.append(pokemonWithForm)
    return pd.concat(allPokemon)


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
    # print(pd.concat([df1, df2, df1]).drop_duplicates(keep=False).sort_values(by='Index').to_string())
    # print((pd.concat([df1, df2, df1]).drop_duplicates(keep=False)).shape)
    return pd.concat(differentLeagues).drop_duplicates()


def dfTestingArea():
    dfTest = df
    # print(dfTest.to_string())
    # print(dfTest.shape)
    # dfTest = df.head(50)
    pve = bestPvEPokemon(dfTest)
    pvp = createPvPData(dfTest)
    bestall = pd.concat([pvp, pve]).drop_duplicates().sort_values(by='Pokemon', ascending=False)
    print(bestall.to_string())
    print(pve.shape)
    print(pvp.shape)
    print(bestall.shape)
    bestall.to_csv("../data/compare_export.csv", index=False)


if __name__ == "__main__":
    # writeEvolutionsToFile()
    # print(readEvolutionsFromFile()[100])
    # dfTestingArea()
    # print(createEvolutionList())
    # TODO manipulate the json file as this is the only way to load it into PokeGenie
    with open("../data/scan_data.json", "r") as filehandle:
        test = json.load(filehandle)
    print(json.dumps(test, indent=2))
    for i in range(3620, 3631):
        print(df[df['Index'] == i])
