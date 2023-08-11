import pandas as pd

pokemonDataAll = pd.read_csv("data/poke_genie_export.csv")
    
if __name__ == "__main__":
    print(pokemonDataAll)