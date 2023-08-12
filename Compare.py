import pandas as pd
import requests
import json

df = pd.read_csv("data/poke_genie_export.csv")


def onlyHighest(df):
    return df.drop_duplicates(subset=['Name', 'Form'])


def dfTestingArea():
    dfTest = df
    # dfTest = df.head(15)
    dfTest = dfTest.sort_values(by=['Name', 'IV Avg'], ascending=[True, False])
    # print(dfTest.to_string())
    print(onlyHighest(dfTest).to_string())


def pokebaseTestingArea():
    id = 538  # 538 is the last entry
    URL = "https://pokeapi.co/api/v2/evolution-chain/" + str(id) + "/"
    data = requests.get(url=URL)

    # print(data.json())
    # df = pd.DataFrame.from_dict(data.json())
    # print(df.to_string())

    json_object = json.loads(data.text)
    # print(json.dumps(json_object, indent=2))

    firstStage = json_object['chain']['species']['name']
    secondStage = json_object['chain']['evolves_to']

    print(firstStage)
    for pokemon in secondStage:
        print(pokemon['species']['name'])

        thirdStage = pokemon['evolves_to']
        for pokemon2 in thirdStage:
            print(pokemon2['species']['name'])


if __name__ == "__main__":
    # dfTestingArea()
    pokebaseTestingArea()
