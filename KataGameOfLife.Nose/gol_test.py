from gol import *

gol = Gol()

def create_full_cells(count):
  return create_cells(count, True)

def create_cells(count, fill=False):
  return [Cell(is_alive=fill) for num in range(0, count)]

def are_beneath(grid, a_pos, b_pos):
  return are_neighbors(grid.check_cell(a_pos), grid.check_cell(b_pos))

def are_neighbors(a_cell, b_cell):
  return \
  a_cell in b_cell.neighbors and \
  b_cell in a_cell.neighbors 

class test_repopulation_rule:
  def when_empty_cell_has_three_alive_neighbors_then_cell_gets_populated_test(self):
    neighbors = create_cells(3, True)
    cell = Cell(neighbors)
    new_cell = gol.generate(cell)
    assert new_cell.is_alive

  def when_empty_cell_has_three_neighbors_its_just_empty_test(self):
    neighbors = create_cells(3, True)
    cell = Cell(neighbors)
    assert not cell.is_alive

  def when_empty_cell_has_no_neighbors_then_cell_stays_empty_test(self):
    cell = Cell()
    new_cell = gol.generate(cell)
    assert not new_cell.is_alive

  def when_empty_cell_has_three_empty_neighbors_then_cell_stays_empty_test(self):
    neighbors = create_cells(3)
    cell = Cell(neighbors)
    new_cell = gol.generate(cell)
    assert not new_cell.is_alive

class test_underpopulation_rule:
  def when_full_cell_has_less_than_two_neighbors_then_cell_becomes_empty_test(self):
    neighbors = create_full_cells(1)
    cell = Cell(neighbors, is_alive=True)
    new_cell = gol.generate(cell)
    assert not new_cell.is_alive

  def when_full_cell_has_two_neighbors_then_cell_stays_alive_test(self):
    neighbors = create_full_cells(2)
    cell = Cell(neighbors, is_alive=True)
    new_cell = gol.generate(cell)
    assert new_cell.is_alive

class test_overpopulation_rule:
  def when_full_cell_has_more_than_three_neighbors_then_cell_becomes_empty_test(self):
    neighbors = create_full_cells(4)
    cell = Cell(neighbors, is_alive=True)
    new_cell = gol.generate(cell)
    assert not new_cell.is_alive

class test_neighbor_uniqueness:
  def when_cell_already_has_same_cell_as_neighbor_then_may_not_accept_that_cell_as_neighbor_test(self):
    a_cell = Cell()
    cell = Cell([a_cell, a_cell])
    assert len(cell.neighbors) == 1


class test_gol_neighbor_bidirection:
  gol = Gol()
  def when_cell_is_assigned_as_neighbor_of_another_then_other_cell_becomes_neighbor_of_assignee_test(self):
    a_cell = Cell()
    b_cell = Cell()
    self.gol.neighbors(a_cell, b_cell)
    assert b_cell in a_cell.neighbors

class test_gol_cell_position:
  def when_cell_is_added_to_position_1_1_then_position_is_occupied_by_cell_test(self):
    g = Gol()
    g.set_cell((1,1), alive=False)
    assert g.check_cell((1,1)) is not None

  def when_another_cell_is_added_to_position_1_1_then_position_is_occupied_by_new_cell_test(self):
    g = Gol()
    g.set_cell((1,1), alive=False)
    g.set_cell((1,1))
    assert g.check_cell((1,1)).is_alive

  def when_a_cell_is_added_to_next_x_axis_position_of_an_existing_cell_then_both_become_neighbors_test(self):
    g = Gol()
    g.set_cell((1,1))
    g.set_cell((2,1))
    assert are_beneath(g, (1,1), (2,1))

  def when_a_cell_is_added_to_previous_x_axis_position_of_an_existing_cell_then_both_become_neighbors_test(self):
    g = Gol()
    g.set_cell((2,1))
    g.set_cell((1,1))
    assert are_beneath(g, (1,1), (2,1))

  def when_a_cell_is_added_to_next_y_axis_position_of_an_existing_cell_then_both_become_neighbors_test(self):
    g = Gol()
    g.set_cell((1,1))
    g.set_cell((1,2))
    assert are_beneath(g, (1,1), (1,2))

  def when_a_cell_is_added_to_previous_x_axis_position_of_an_existing_cell_then_both_become_neighbors_test(self):
    g = Gol()
    g.set_cell((1,2))
    g.set_cell((1,1))
    assert are_beneath(g, (1,1), (1,2))

