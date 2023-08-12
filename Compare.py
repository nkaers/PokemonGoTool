import pandas as pd

df = pd.read_csv("data/poke_genie_export.csv")


def onlyHighestCP(df):
    return df.drop_duplicates(subset=['Name'])


if __name__ == "__main__":
    dfTest = df.head(15)
    dfTest = dfTest.sort_values(by=['Name', 'CP'], ascending=[True, False])
    #print(dfTest.to_string())
    print(onlyHighestCP(dfTest).to_string())
