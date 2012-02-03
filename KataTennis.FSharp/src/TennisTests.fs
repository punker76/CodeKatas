module TennisTests

open Tennis
open Xunit

[<Fact>]
let when_score_is_love_love_then_game_is_not_over () =
  Assert.False(
    game |> isover
  )

[<Fact>]
let when_score_is_forty_love_and_player_one_scores_then_game_is_over () =
  Assert.True(
    game (Forty, Love)
      |> score PlayerOne
      |> isover
  )
